using System.Collections.Generic;
using TMPro;

public class GameManager
{

    public int playerMoney;
    public List<InterchangeableItemSO> playerStorage = new List<InterchangeableItemSO>();


    public void Init()
    {
        // 여기에 플레이어 세이브 데이터 받아와서 연동하는 부분 구현 필요함
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
