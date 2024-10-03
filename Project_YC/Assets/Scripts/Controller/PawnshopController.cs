using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;

public class PawnshopController : SceneController
{
    public CharacterController characterController;

    private TMP_InputField _valueInputField;

    void Start()
    {
        characterController = transform.AddComponent<CharacterController>();

        Manager.Game.playerMoney = 5000;
        Manager.UI.mainCanvas.transform.Find("BasicFrame/PlayerMoney").GetComponent<TextMeshProUGUI>().text = $"{Manager.Game.playerMoney}";

        Manager.UI.GetUIObject((int)Defines.SceneComponents.PawnshopUI.TradeAcceptButton).GetComponent<Button>().onClick.AddListener(OnClickAcceptButton);
        Manager.UI.GetUIObject((int)Defines.SceneComponents.PawnshopUI.TradeNegoButton).GetComponent<Button>().onClick.AddListener(OnClickNegoButton);
        Manager.UI.GetUIObject((int)Defines.SceneComponents.PawnshopUI.TradeDenyButton).GetComponent<Button>().onClick.AddListener(OnClickDenyButton);

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
}
