using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class PawnshopController : SceneController
{
    public CharacterController characterController;

    private List<int> customerQueue;
    private TMP_InputField _valueInputField;


    void Start()
    {
        characterController = transform.AddComponent<CharacterController>();

        customerQueue = new List<int>();
        // 자동 대화 진행을 위한 임시 작성 부분. 손님 랜덤 소환 기능 구현시 대체 바람.
        {
            customerQueue.Add(90001);
            customerQueue.Add(90002);
            characterController.UpdateCharacterData(customerQueue[0]);
            Manager.Dialogue.TriggerDialogue(Manager.Data.characterDB[customerQueue[0]].dialogueId, Manager.Data.characterDB[customerQueue[0]].itemId);
        }

        Manager.Game.playerMoney = 5000;
        Manager.UI.mainCanvas.transform.Find("BasicFrame/PlayerMoney").GetComponent<TextMeshProUGUI>().text = $"{Manager.Game.playerMoney}";

        Manager.UI.GetUIObject((int)Defines.SceneComponents.PawnshopUI.TradeAcceptButton).GetComponent<Button>().onClick.AddListener(OnClickAcceptButton);
        Manager.UI.GetUIObject((int)Defines.SceneComponents.PawnshopUI.TradeNegoButton).GetComponent<Button>().onClick.AddListener(OnClickNegoButton);
        Manager.UI.GetUIObject((int)Defines.SceneComponents.PawnshopUI.TradeDenyButton).GetComponent<Button>().onClick.AddListener(OnClickDenyButton);

        Manager.Dialogue.dialogueEventAction += DialogueEventHandler;

        _valueInputField = Manager.UI.GetUIObject((int)Defines.SceneComponents.PawnshopUI.ValueInputField).GetComponent<TMP_InputField>();
    }


    private void OnClickAcceptButton()
    {
        Manager.Dialogue.AcceptTrade(characterController.currentCost);
    }


    private void OnClickDenyButton()
    {
        Manager.Dialogue.DenyTrade();
    }


    private void OnClickNegoButton()
    {
        int negoResult = characterController.TryNegotiation(Int32.Parse(_valueInputField.text));

        if (negoResult == 0)
        {
            Manager.Dialogue.AcceptNego();
        }
        else
        {
            _valueInputField.text = $"{negoResult}";
            Manager.Dialogue.DenyNego();
        }
    }


    private void EndDialogue()
    {
        customerQueue.RemoveAt(0);
        if (customerQueue.Count > 0)
        {
            characterController.UpdateCharacterData(customerQueue[0]);
            TriggerDialogue();
        }
        else
        {
            Manager.Dialogue.dialogueEventAction -= DialogueEventHandler;
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
            case Defines.Enums.DialogueEvent.End:
                {
                    EndDialogue();
                    break;
                }
        }
    }
}
