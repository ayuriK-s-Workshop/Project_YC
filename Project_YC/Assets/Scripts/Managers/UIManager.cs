using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public GameObject mainCanvas;

    private List<GameObject> uiComponents = new List<GameObject>();

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
                        uiComponents.Add(GameObject.Find(components.ToString()));
                    }
                    break;
                }
        }
    }
}
