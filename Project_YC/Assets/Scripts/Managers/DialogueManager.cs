using System;
using TMPro;
using UnityEngine;

public class DialogueManager
{
    #region 대화 관련 필드
    private GameObject _dialogueSection;

    // 교환 아이템 프리팹 & 인스턴스
    private GameObject _tradeItemObj;
    private GameObject _tradeItemInstance;

    // 대화 박스 프리팹 & 인스턴스
    private GameObject _opponentDialogueObj;
    private GameObject _playerDialogueObj;
    private GameObject _opponentDialogueInstance;
    private GameObject _playerDialogueInstance;

    // 현재 대화 & 아이템 데이터
    private DialogueSO _currentDialogueData;
    private InterchangeableItemSO _targetItemData;

    private bool _isDialogueEnd;
    private int _currentDialogueIndex;
    #endregion

    public void Init()
    {
        _tradeItemObj = Resources.Load("Prefabs/ItemObject") as GameObject;
        _dialogueSection = Manager.UIManager.mainCanvas.transform.Find("BasicFrame/DialogueSection").gameObject;
        _opponentDialogueObj = Resources.Load("Prefabs/OpponentDialogue") as GameObject;
        _playerDialogueObj = Resources.Load("Prefabs/PlayerDialogue") as GameObject;
    }


    // 대화 발생 메소드
    public void TriggerDialogue(int dialogueId, int itemId)
    {
        _currentDialogueData = Manager.DataManager.dialogueDB[dialogueId];
        _currentDialogueIndex = 0;
        _targetItemData = Manager.DataManager.interchangeableItemDB[itemId];
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
            if (_playerDialogueInstance != null)
            {
                GameObject.Destroy(_playerDialogueInstance);
            }
            if (_opponentDialogueInstance != null)
            {
                GameObject.Destroy(_opponentDialogueInstance);
            }
            if (_tradeItemInstance != null)
            {
                GameObject.Destroy(_tradeItemInstance);
            }

            _isDialogueEnd = false;
            return;
        }

        // 상대방 대화인지 플레이어 대화인지 체크 후 대화 표시
        if (_currentDialogueData.dialogues[index].isOpponent)
        {
            if (_playerDialogueInstance != null)
            {
                GameObject.Destroy(_playerDialogueInstance);
            }
            if (_opponentDialogueInstance == null)
            {
                _opponentDialogueInstance = GameObject.Instantiate(_opponentDialogueObj, _dialogueSection.transform);
            }
            _opponentDialogueInstance.transform.Find("TextBG/Text").GetComponent<TextMeshProUGUI>().text = _currentDialogueData.dialogues[index].text;
        }
        else if (!_currentDialogueData.dialogues[index].isOpponent)
        {
            if (_opponentDialogueInstance != null)
            {
                GameObject.Destroy(_opponentDialogueInstance);
            }
            if (_playerDialogueInstance == null)
            {
                _playerDialogueInstance = GameObject.Instantiate(_playerDialogueObj, _dialogueSection.transform);
            }
            _playerDialogueInstance.transform.Find("TextBG/Text").GetComponent<TextMeshProUGUI>().text = _currentDialogueData.dialogues[index].text;
        }

        // 대화 중 거래 시작
        if (_currentDialogueData.dialogues[index].isTradeStart)
        {
            InstantiateTargetItem();
        }

        if (_currentDialogueData.dialogues[index].tradeAcceptIndex == 0 && _currentDialogueData.dialogues[index].tradeDenyIndex == 0)
        {
            _isDialogueEnd = _currentDialogueData.dialogues[index].isEnd;
            _currentDialogueIndex = _currentDialogueData.dialogues[index].justNext ? _currentDialogueIndex + 1 : _currentDialogueData.dialogues[index].nextIndex;
        }
    }


    private void InstantiateTargetItem()
    {
        _tradeItemInstance = GameObject.Instantiate(_tradeItemObj);
        _tradeItemInstance.GetComponent<SpriteRenderer>().sprite = _targetItemData.texture;
    }


    public void AcceptTrade()
    {
        Manager.GameManager.UpdatePlayerMoney(-_targetItemData.actualValue);
        _currentDialogueIndex = _currentDialogueData.dialogues[_currentDialogueIndex].tradeAcceptIndex;
        ChangeDialogue();
    }
    public void DenyTrade()
    {
        _currentDialogueIndex = _currentDialogueData.dialogues[_currentDialogueIndex].tradeDenyIndex;
        ChangeDialogue();
    }
}
