using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public GameObject mainCanvas;

    public void Init()
    {
        mainCanvas = GameObject.Find("MainCanvas");
    }
}
