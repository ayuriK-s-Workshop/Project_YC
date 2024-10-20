using System.Collections.Generic;
using TMPro;

public class GameManager
{

    public int playerMoney;
    public Dictionary<int, int> playerStorage = new Dictionary<int, int>();


    public void Init()
    {
        // ���⿡ �÷��̾� ���̺� ������ �޾ƿͼ� �����ϴ� �κ� ���� �ʿ���
    }


    public void UpdatePlayerMoney(int value)
    {
        playerMoney += value;
        Manager.UI.mainCanvas.transform.Find("BasicFrame/PlayerMoney").GetComponent<TextMeshProUGUI>().text = $"{playerMoney}";
    }


    public void AddItemInPlayerStorage(InterchangeableItemSO item)
    {
        if (!playerStorage.ContainsKey(item.id))
            playerStorage.Add(item.id, 0);
        playerStorage[item.id] += 1;
    }
}
