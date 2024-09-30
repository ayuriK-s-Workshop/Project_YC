using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
