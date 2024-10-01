using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public GameObject mainCanvas;

    // Key : ������ �ε���, Value : UI ������Ʈ
    private Dictionary<int, GameObject> uiComponents = new Dictionary<int, GameObject>();

    public void Init()
    {
        mainCanvas = GameObject.Find("MainCanvas");
        uiComponents.Clear();

        switch (Manager.Scene.currentScene)
        {
            case Defines.Enums.Scenes.PawnshopScene:
                {
                    foreach (Defines.SceneComponents.PawnshopUI components in Enum.GetValues(typeof(Defines.SceneComponents.PawnshopUI)))
                    {
                        uiComponents.Add((int)components, GameObject.Find(components.ToString()));
                    }
                    break;
                }
        }
    }

    public GameObject GetUIObject(int enumIndex)
    {
        return uiComponents[enumIndex];
    }
}
