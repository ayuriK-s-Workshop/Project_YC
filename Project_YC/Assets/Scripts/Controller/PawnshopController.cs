using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PawnshopController : SceneController
{
    public CharacterController characterController;

    private List<int> customerQueue;

    private Button tradeAcceptButton;
    private Button tradeNegoButton;
    private Button tradeDenyButton;

    private TMP_InputField _valueInputField;


    void Start()
    {
        characterController = transform.AddComponent<CharacterController>();

        customerQueue = new List<int>();
        // �ڵ� ��ȭ ������ ���� �ӽ� �ۼ� �κ�. �մ� ���� ��ȯ ��� ������ ��ü �ٶ�.
        {
            customerQueue.Add(90001);
            customerQueue.Add(90002);
            characterController.UpdateCharacterData(customerQueue[0]);
            Manager.Dialogue.TriggerDialogue(Manager.Data.characterDB[customerQueue[0]].dialogueId, Manager.Data.characterDB[customerQueue[0]].itemId);
        }

        Manager.Game.playerMoney = 5000;
        Manager.Dialogue.dialogueEventAction += DialogueEventHandler;

        InitializeUI();
    }


    private void InitializeUI()
    {
        Manager.UI.mainCanvas.transform.Find("BasicFrame/PlayerMoney").GetComponent<TextMeshProUGUI>().text = $"{Manager.Game.playerMoney}";

        tradeAcceptButton = Manager.UI.GetUIObject<Button>((int)Defines.SceneComponents.PawnshopUI.TradeAcceptButton);
        tradeAcceptButton.onClick.AddListener(OnClickAcceptButton);

        tradeNegoButton = Manager.UI.GetUIObject<Button>((int)Defines.SceneComponents.PawnshopUI.TradeNegoButton);
        tradeNegoButton.onClick.AddListener(OnClickNegoButton);

        tradeDenyButton = Manager.UI.GetUIObject<Button>((int)Defines.SceneComponents.PawnshopUI.TradeDenyButton);
        tradeDenyButton.onClick.AddListener(OnClickDenyButton);

        _valueInputField = Manager.UI.GetUIObject<TMP_InputField>((int)Defines.SceneComponents.PawnshopUI.ValueInputField);
        _valueInputField.text = "-----";

        SetUIInteractable(false);
    }


    private void SetUIInteractable(bool value)
    {
        tradeAcceptButton.interactable = value;
        tradeNegoButton.interactable = value;
        tradeDenyButton.interactable = value;
        _valueInputField.interactable = value;
    }


    private void OnClickAcceptButton()
    {
        SetUIInteractable(false);
        Manager.Dialogue.AcceptTrade(characterController.currentCost);
    }


    private void OnClickDenyButton()
    {
        SetUIInteractable(false);
        Manager.Dialogue.DenyTrade();
    }


    private void OnClickNegoButton()
    {
        SetUIInteractable(false);
        int negoResult = characterController.TryNegotiation(Int32.Parse(_valueInputField.text));

        if (negoResult == 0)
        {
            Manager.Dialogue.AcceptNego();
        }
        else
        {
            //_valueInputField.text = $"{negoResult}";
            Manager.Dialogue.DenyNego();
        }
    }


    private void TriggerDialogue()
    {
        Manager.Dialogue.TriggerDialogue(Manager.Data.characterDB[customerQueue[0]].dialogueId, Manager.Data.characterDB[customerQueue[0]].itemId);
    }


    private void DialogueEventHandler(Defines.Enums.DialogueEvent e)
    {
        switch (e)
        {
            case Defines.Enums.DialogueEvent.Start:
                {

                    break;
                }
            case Defines.Enums.DialogueEvent.TradeStart:
                {
                    DialogueTradeStart();
                    break;
                }
            case Defines.Enums.DialogueEvent.Paused:
                {
                    DialoguePaused();
                    break;
                }
            case Defines.Enums.DialogueEvent.End:
                {
                    DialogueEnd();
                    break;
                }
        }
    }


    private void DialogueTradeStart()
    {
        SetUIInteractable(true);
        _valueInputField.text = $"{Manager.Data.interchangeableItemDB[Manager.Data.characterDB[customerQueue[0]].itemId].actualValue}";
    }


    private void DialoguePaused()
    {
        SetUIInteractable(true);
        _valueInputField.text = $"{characterController.currentCost}";
    }


    private void DialogueEnd()
    {
        _valueInputField.text = "-----";
        customerQueue.RemoveAt(0);
        if (customerQueue.Count > 0)
        {
            characterController.UpdateCharacterData(customerQueue[0]);
            TriggerDialogue();
        }
        else
        {
            Manager.Dialogue.dialogueEventAction -= DialogueEventHandler;
            Manager.Scene.LoadScene(Defines.Enums.Scenes.ResistanceManageScene);
        }
    }
}
