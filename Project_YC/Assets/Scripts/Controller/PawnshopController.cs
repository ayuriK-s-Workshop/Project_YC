using TMPro;
using UnityEngine.UI;

public class PawnshopController : SceneController
{
    void Start()
    {
        Manager.Game.playerMoney = 5000;
        Manager.UI.mainCanvas.transform.Find("BasicFrame/PlayerMoney").GetComponent<TextMeshProUGUI>().text = $"{Manager.Game.playerMoney}";

        Manager.UI.GetUIObject((int)Defines.SceneComponents.PawnshopUI.TradeAcceptButton).GetComponent<Button>().onClick.AddListener(OnClickAcceptButton);
        Manager.UI.GetUIObject((int)Defines.SceneComponents.PawnshopUI.TradeDenyButton).GetComponent<Button>().onClick.AddListener(OnClickDenyButton);
    }

    private void OnClickAcceptButton()
    {
        Manager.Dialogue.AcceptTrade();
    }

    private void OnClickDenyButton()
    {
        Manager.Dialogue.DenyTrade();
    }
}
