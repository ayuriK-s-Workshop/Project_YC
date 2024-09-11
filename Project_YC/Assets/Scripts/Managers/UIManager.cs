using UnityEngine;

public class UIManager
{
    public GameObject mainCanvas;

    public void Init()
    {
        mainCanvas = GameObject.Find("MainCanvas");
    }
}
