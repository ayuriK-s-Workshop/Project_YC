using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager
{
    #region 대화 관련 필드
    public Action<Defines.Enums.DialogueEvent> dialogueEventAction;

    private GameObject _dialogueSection;

    // 교환 아이템 프리팹 & 인스턴스
    private GameObject _tradeItemObj;
    private GameObject _tradeItemInstance;

    // 대화 박스 프리팹 & 인스턴스
    private GameObject _opponentDialogueObj;
    private GameObject _playerDialogueObj;
    private GameObject _opponentDialogueInstance;
    private GameObject _playerDialogueInstance;
    private TextMeshProUGUI _opponentDialogueTMP;
    private TextMeshProUGUI _playerDialogueTMP;

    // 현재 대화 & 아이템 데이터
    private DialogueSO _currentDialogueData;
    private List<Defines.Classes.DialogueText> _currentDialogue;
    private InterchangeableItemSO _targetItemData;
    private Coroutine _dialogueCoroutine;

    private bool _isDialogueEnd;
    private int _currentDialogueIndex;
    #endregion


    public void Init()
    {
        _tradeItemObj = Resources.Load("Prefabs/ItemObject") as GameObject;
        _dialogueSection = Manager.UI.mainCanvas.transform.Find("BasicFrame/DialogueSection").gameObject;
        _opponentDialogueObj = Resources.Load("Prefabs/OpponentDialogue") as GameObject;
        _playerDialogueObj = Resources.Load("Prefabs/PlayerDialogue") as GameObject;
        _opponentDialogueInstance = GameObject.Instantiate(_opponentDialogueObj, _dialogueSection.transform);
        _playerDialogueInstance = GameObject.Instantiate(_playerDialogueObj, _dialogueSection.transform);
        _opponentDialogueTMP = _opponentDialogueInstance.transform.Find("TextBG/Text").GetComponent<TextMeshProUGUI>();
        _playerDialogueTMP = _playerDialogueInstance.transform.Find("TextBG/Text").GetComponent<TextMeshProUGUI>();
    }


    // 대화 발생 메소드
    public void TriggerDialogue(int dialogueId, int itemId)
    {
        _currentDialogueData = Manager.Data.dialogueDB[dialogueId];
        _currentDialogue = _currentDialogueData.dialogues;
        _currentDialogueIndex = 0;
        _targetItemData = Manager.Data.interchangeableItemDB[itemId];
        ChangeDialogue(_currentDialogueIndex);
    }


    // 다음 대화 넘어가는 메소드. 오버로딩
    public void ChangeDialogue()
    {
        ChangeDialogue(_currentDialogueIndex);
    }


    // 특정 대화 넘어가는 메소드
    public void ChangeDialogue(int index)
    {
        // 대화 끝난 경우
        if (_isDialogueEnd)
        {
            Manager.ManagerInstance.StopCoroutine(_dialogueCoroutine);

            _opponentDialogueTMP.text = "";
            _playerDialogueTMP.text = "";

            if (_tradeItemInstance != null)
            {
                GameObject.Destroy(_tradeItemInstance);
            }

            _isDialogueEnd = false;
            dialogueEventAction.Invoke(Defines.Enums.DialogueEvent.End);
            return;
        }

        _dialogueCoroutine = Manager.ManagerInstance.StartCoroutine(ShowDialogue(index));
    }


    // 기본 대화 로직 및 애니메이션
    private IEnumerator ShowDialogue(int index)
    {
        TextMeshProUGUI targetTMP = null;

        // 상대방 대화인지 플레이어 대화인지 체크 후 대화 표시
        if (_currentDialogue[index].isOpponent)
        {
            _playerDialogueTMP.text = "";
            targetTMP = _opponentDialogueInstance.transform.Find("TextBG/Text").GetComponent<TextMeshProUGUI>();
        }

        else if (!_currentDialogue[index].isOpponent)
        {
            _opponentDialogueTMP.text = "";
            targetTMP = _playerDialogueInstance.transform.Find("TextBG/Text").GetComponent<TextMeshProUGUI>();
        }

        targetTMP.text = "";
        for (int i = 0; i < _currentDialogue[index].text.Length; i++)
        {
            targetTMP.text += _currentDialogue[index].text[i];
            yield return new WaitForSeconds(Values.Time.SPEED_DEFAULT_TEXT_ANIMATION);
        }

        // 대화 중 거래 시작
        if (_currentDialogue[index].isTradeStart)
        {
            dialogueEventAction.Invoke(Defines.Enums.DialogueEvent.TradeStart);
            InstantiateTargetItem();
        }

        _isDialogueEnd = _currentDialogue[index].isEnd;
        if (_currentDialogue.Count > index + 1)
        {
            _currentDialogueIndex = _currentDialogue[index].justNext ? _currentDialogueIndex + 1 : _currentDialogue[index].nextIndex;
        }
        else if (!_isDialogueEnd)
        {
            dialogueEventAction.Invoke(Defines.Enums.DialogueEvent.Paused);
        }

        if (_isDialogueEnd || _currentDialogue.Count > index)
        {
            yield return new WaitForSeconds(Values.Time.DELAY_DEFAULT_TEXT_PROCEED);
        }

        if (_isDialogueEnd || _currentDialogue.Count > index + 1)
        {
            ChangeDialogue(_currentDialogueIndex);
        }
    }


    private void InstantiateTargetItem()
    {
        _tradeItemInstance = GameObject.Instantiate(_tradeItemObj);
        _tradeItemInstance.GetComponent<SpriteRenderer>().sprite = _targetItemData.texture;
    }


    public void AcceptTrade(int value)
    {
        Manager.Game.UpdatePlayerMoney(-value);
        _currentDialogueIndex = 0;
        _currentDialogue = _currentDialogueData.acceptTradeText;
        ChangeDialogue();
    }


    public void DenyTrade()
    {
        _currentDialogueIndex = 0;
        _currentDialogue = _currentDialogueData.denyTradeText;
        ChangeDialogue();
    }


    public void AcceptNego()
    {
        _currentDialogueIndex = 0;
        _currentDialogue = _currentDialogueData.acceptNegoText;
        ChangeDialogue();
    }


    public void DenyNego()
    {
        _currentDialogueIndex = 0;
        _currentDialogue = _currentDialogueData.denyNegoText;
        ChangeDialogue();
    }
}
