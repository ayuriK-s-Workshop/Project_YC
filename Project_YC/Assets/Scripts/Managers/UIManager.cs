using System;
using System.Collections.Generic;
using UnityEngine;

public class UIManager
{
    public GameObject mainCanvas;

    // Key : 열거형 인덱스, Value : UI 오브젝트
    private Dictionary<int, GameObject> uiComponents = new Dictionary<int, GameObject>();

    private List<GameObject> uiInstaces = new List<GameObject>();

    public void Init()
    {
        mainCanvas = GameObject.Find("MainCanvas");
    }

    public void UpdateUI()
    {
        mainCanvas = GameObject.Find("MainCanvas");

        uiComponents.Clear();
        uiInstaces.Clear();

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

            case Defines.Enums.Scenes.ResistanceManageScene:
                {
                    foreach (Defines.SceneComponents.ResistanceManageUI components in Enum.GetValues(typeof(Defines.SceneComponents.ResistanceManageUI)))
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

    public T GetUIObject<T>(int enumIndex)
    {
        return uiComponents[enumIndex].GetComponent<T>();
    }

    public void ActivateUIInstace(GameObject go)
    {
        go.SetActive(true);
        uiInstaces.Add(go);
    }

    // 무조건 후입선출로 설계함
    public void DeactivateUIInstance()
    {
        if (uiInstaces.Count <= 0)
            return;
        uiInstaces[uiInstaces.Count - 1].SetActive(false);
        uiInstaces.RemoveAt(uiInstaces.Count - 1);
    }
}
