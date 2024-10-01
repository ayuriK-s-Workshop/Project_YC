using TMPro;

public class PawnshopController : SceneController
{
    void Start()
    {
        Manager.Game.playerMoney = 5000;
        Manager.UI.mainCanvas.transform.Find("BasicFrame/PlayerMoney").GetComponent<TextMeshProUGUI>().text = $"{Manager.Game.playerMoney}";
    }

    void Update()
    {
        
    }
}
