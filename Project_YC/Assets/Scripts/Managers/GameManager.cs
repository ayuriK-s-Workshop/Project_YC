using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager
{
    public int playerMoney;

    public void Init()
    {
        playerMoney = 5000;
        Manager.UIManager.mainCanvas.transform.Find("BasicFrame/PlayerMoney").GetComponent<TextMeshProUGUI>().text = $"{playerMoney}";
    }

    public void UpdatePlayerMoney(int value)
    {
        playerMoney += value;
        Manager.UIManager.mainCanvas.transform.Find("BasicFrame/PlayerMoney").GetComponent<TextMeshProUGUI>().text = $"{playerMoney}";
    }
}
