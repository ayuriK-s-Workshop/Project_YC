using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public GameObject mainCanvas;

    // Key : 열거형 인덱스, Value : UI 오브젝트
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

    public T GetUIObject<T>(int enumIndex)
    {
        return uiComponents[enumIndex].GetComponent<T>();
    }
}
