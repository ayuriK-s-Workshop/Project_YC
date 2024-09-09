using System;
using System.Collections;
using System.Collections.Generic;
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

    public void TriggerDialogue(int dialogueId)
    {
        _currentDialogue = Manager.DataManager.dialogueDB[dialogueId];
        _currentDialogueIndex = 0;
        ChangeDialogue(_currentDialogueIndex);
    }

    public void ChangeDialogue()
    {
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
            return;
        }

        if (_currentDialogue.dialogues[_currentDialogueIndex].isOpponent)
        {
            if (_playerDialogueInstance != null)
            {
                GameObject.Destroy(_playerDialogueInstance);
            }
            if (_opponentDialogueInstance == null)
            {
                _opponentDialogueInstance = GameObject.Instantiate(_opponentDialogueObj, _dialogueSection.transform);
            }
            _opponentDialogueInstance.transform.Find("TextBG/Text").GetComponent<TextMeshProUGUI>().text = _currentDialogue.dialogues[_currentDialogueIndex].text;
        }
        else if (!_currentDialogue.dialogues[_currentDialogueIndex].isOpponent)
        {
            if (_opponentDialogueInstance != null)
            {
                GameObject.Destroy(_opponentDialogueInstance);
            }
            if (_playerDialogueInstance == null)
            {
                _playerDialogueInstance = GameObject.Instantiate(_playerDialogueObj, _dialogueSection.transform);
            }
            _playerDialogueInstance.transform.Find("TextBG/Text").GetComponent<TextMeshProUGUI>().text = _currentDialogue.dialogues[_currentDialogueIndex].text;
        }
        _isDialogueEnd = _currentDialogue.dialogues[_currentDialogueIndex].isEnd;
        _currentDialogueIndex = _currentDialogue.dialogues[_currentDialogueIndex].nextIndex;
    }

    public void ChangeDialogue(int index)
    {
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
        }

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
            if (_playerDialogueInstance != null)
            {
                _playerDialogueInstance = GameObject.Instantiate(_playerDialogueObj, _dialogueSection.transform);
            }
            _playerDialogueInstance.transform.Find("TextBG/Text").GetComponent<TextMeshProUGUI>().text = _currentDialogue.dialogues[index].text;
        }
        _isDialogueEnd = _currentDialogue.dialogues[index].isEnd;
        _currentDialogueIndex = _currentDialogue.dialogues[index].nextIndex;
    }
}
