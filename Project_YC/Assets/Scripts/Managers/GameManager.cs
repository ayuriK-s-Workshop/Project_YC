using TMPro;

public class GameManager
{
    public int playerMoney;
    public SceneController sceneController;

    public void Init()
    {
        switch (Manager.Scene.currentScene)
        {
            case Defines.Enums.Scenes.PawnshopScene:
                {
                    sceneController = Manager.ManagerInstance.gameObject.AddComponent<PawnshopController>();
                    break;
                }
        }
    }

    public void UpdatePlayerMoney(int value)
    {
        playerMoney += value;
        Manager.UI.mainCanvas.transform.Find("BasicFrame/PlayerMoney").GetComponent<TextMeshProUGUI>().text = $"{playerMoney}";
    }
}
