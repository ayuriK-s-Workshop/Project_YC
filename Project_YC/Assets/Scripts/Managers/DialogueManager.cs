using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;

public class DialogueManager
{
    private GameObject _dialogueSection;

    private GameObject _opponentDialogueObj;
    private GameObject _playerDialogueObj;
    private GameObject _opponentDialogueInstance;
    private GameObject _playerDialogueInstance;

    private DialogueSO _currentDialogue;
    private bool _isDialogueEnd;
    private int _currentDialogueIndex;

    public void Init()
    {
        _dialogueSection = Manager.UIManager.mainCanvas.transform.Find("BasicFrame/DialogueSection").gameObject;
        _opponentDialogueObj = Resources.Load("Prefabs/OpponentDialogue") as GameObject;
        _playerDialogueObj = Resources.Load("Prefabs/PlayerDialogue") as GameObject;
    }

    // 대화 발생 메소드
    public void TriggerDialogue(int dialogueId)
    {
        _currentDialogue = Manager.DataManager.dialogueDB[dialogueId];
        _currentDialogueIndex = 0;
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
            if (_opponentDialogueInstance == null)
            {
                GameObject.Destroy(_opponentDialogueInstance);
            }

            return;
        }

        // 상대방 대화인지 플레이어 대화인지 체크 후 대화 표시
        if (_currentDialogue.dialogues[index].isOpponent)
        {
            if (_playerDialogueInstance != null)
            {
                GameObject.Destroy(_playerDialogueInstance);
            }
            if (_opponentDialogueInstance == null)
            {
                _opponentDialogueInstance = GameObject.Instantiate(_opponentDialogueObj, _dialogueSection.transform);
            }
            _opponentDialogueInstance.transform.Find("TextBG/Text").GetComponent<TextMeshProUGUI>().text = _currentDialogue.dialogues[index].text;
        }
        else if (!_currentDialogue.dialogues[index].isOpponent)
        {
            if (_opponentDialogueInstance != null)
            {
                GameObject.Destroy(_opponentDialogueInstance);
            }
            if (_playerDialogueInstance == null)
            {
                _playerDialogueInstance = GameObject.Instantiate(_playerDialogueObj, _dialogueSection.transform);
            }
            _playerDialogueInstance.transform.Find("TextBG/Text").GetComponent<TextMeshProUGUI>().text = _currentDialogue.dialogues[index].text;
        }

        _isDialogueEnd = _currentDialogue.dialogues[index].isEnd;
        _currentDialogueIndex = _currentDialogue.dialogues[index].justNext ? _currentDialogueIndex + 1 : _currentDialogue.dialogues[index].nextIndex;
    }
}
