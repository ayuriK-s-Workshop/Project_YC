using System.Collections.Generic;
using TMPro;

public class GameManager
{

    public int playerMoney;
    public List<InterchangeableItemSO> playerStorage;


    public void Init()
    {
        playerStorage = new List<InterchangeableItemSO>();
    }


    public void UpdatePlayerMoney(int value)
    {
        playerMoney += value;
        Manager.UI.mainCanvas.transform.Find("BasicFrame/PlayerMoney").GetComponent<TextMeshProUGUI>().text = $"{playerMoney}";
    }


    public void AddItemInPlayerStorage(InterchangeableItemSO item)
    {
        playerStorage.Add(item);
    }
}
