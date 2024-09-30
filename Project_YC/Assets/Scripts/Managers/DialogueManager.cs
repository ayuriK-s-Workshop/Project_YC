using System;
using System.Collections;
using System.Reflection;
using TMPro;
using UnityEngine;

public class DialogueManager
{
    #region ��ȭ ���� �ʵ�
    private GameObject _dialogueSection;

    // ��ȯ ������ ������ & �ν��Ͻ�
    private GameObject _tradeItemObj;
    private GameObject _tradeItemInstance;

    // ��ȭ �ڽ� ������ & �ν��Ͻ�
    private GameObject _opponentDialogueObj;
    private GameObject _playerDialogueObj;
    private GameObject _opponentDialogueInstance;
    private GameObject _playerDialogueInstance;

    // ���� ��ȭ & ������ ������
    private DialogueSO _currentDialogueData;
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
    }


    // ��ȭ �߻� �޼ҵ�
    public void TriggerDialogue(int dialogueId, int itemId)
    {
        _currentDialogueData = Manager.Data.dialogueDB[dialogueId];
        _currentDialogueIndex = 0;
        _targetItemData = Manager.Data.interchangeableItemDB[itemId];
        ChangeDialogue(_currentDialogueIndex);
    }


    // ���� ��ȭ �Ѿ�� �޼ҵ�. �����ε�
    public void ChangeDialogue()
    {
        ChangeDialogue(_currentDialogueIndex);
    }


    // Ư�� ��ȭ �Ѿ�� �޼ҵ�
    public void ChangeDialogue(int index)
    {
        // ��ȭ ���� ���
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

        _dialogueCoroutine = Manager.ManagerInstance.StartCoroutine(ShowDialogue(index));
    }


    // �⺻ ��ȭ ���� �� �ִϸ��̼�
    private IEnumerator ShowDialogue(int index)
    {
        TextMeshProUGUI targetTMP = null;

        // ���� ��ȭ���� �÷��̾� ��ȭ���� üũ �� ��ȭ ǥ��
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
            targetTMP = _opponentDialogueInstance.transform.Find("TextBG/Text").GetComponent<TextMeshProUGUI>();
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
            targetTMP = _playerDialogueInstance.transform.Find("TextBG/Text").GetComponent<TextMeshProUGUI>();
            _playerDialogueInstance.transform.Find("TextBG/Text").GetComponent<TextMeshProUGUI>().text = _currentDialogueData.dialogues[index].text;
        }

        targetTMP.text = "";
        for (int i = 0; i < _currentDialogueData.dialogues[index].text.Length; i++)
        {
            targetTMP.text += _currentDialogueData.dialogues[index].text[i];
            yield return new WaitForSeconds(Values.Time.SPEED_DEFAULT_TEXT_ANIMATION);
        }

        // ��ȭ �� �ŷ� ����
        if (_currentDialogueData.dialogues[index].isTradeStart)
        {
            InstantiateTargetItem();
        }

        if (_currentDialogueData.dialogues[index].tradeAcceptIndex == 0 && _currentDialogueData.dialogues[index].tradeDenyIndex == 0)
        {
            _isDialogueEnd = _currentDialogueData.dialogues[index].isEnd;
            _currentDialogueIndex = _currentDialogueData.dialogues[index].justNext ? _currentDialogueIndex + 1 : _currentDialogueData.dialogues[index].nextIndex;
        }

        yield return new WaitForSeconds(Values.Time.DELAY_DEFAULT_TEXT_PROCEED);
        if (!_currentDialogueData.dialogues[index].isTradeStart)
        {
            ChangeDialogue(_currentDialogueIndex);
        }
    }


    private void InstantiateTargetItem()
    {
        _tradeItemInstance = GameObject.Instantiate(_tradeItemObj);
        _tradeItemInstance.GetComponent<SpriteRenderer>().sprite = _targetItemData.texture;
    }


    public void AcceptTrade()
    {
        Manager.Game.UpdatePlayerMoney(-_targetItemData.actualValue);
        _currentDialogueIndex = _currentDialogueData.dialogues[_currentDialogueIndex].tradeAcceptIndex;
        ChangeDialogue();
    }
    public void DenyTrade()
    {
        _currentDialogueIndex = _currentDialogueData.dialogues[_currentDialogueIndex].tradeDenyIndex;
        ChangeDialogue();
    }
}
