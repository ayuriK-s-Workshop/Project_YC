using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public Defines.Enums.Scenes currentScene;

    public SceneController sceneController;


    public void Init()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        UpdateCurrentScene();
    }


    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateCurrentScene();
        Manager.UI.UpdateUI();
        UpdateCurrentSceneScript();
    }


    public void UpdateCurrentScene()
    {
        foreach (Defines.Enums.Scenes s in Enum.GetValues(typeof(Defines.Enums.Scenes)))
        {
            if (SceneManager.GetActiveScene().name == s.ToString())
            {
                currentScene = s;
                break;
            }
        }

        // Manager ��ũ��Ʈ�� ������ �ٸ� ��ũ��Ʈ ������Ʈ ����
        foreach (MonoBehaviour component in Manager.ManagerInstance.GetComponents<MonoBehaviour>())
        {
            if (component == Manager.ManagerInstance)
                continue;
            GameObject.Destroy(component);
        }
    }


    private void UpdateCurrentSceneScript()
    {
        switch (currentScene)
        {
            case Defines.Enums.Scenes.PawnshopScene:
                {
                    sceneController = Manager.ManagerInstance.gameObject.AddComponent<PawnshopController>();
                    break;
                }
            case Defines.Enums.Scenes.ResistanceManageScene:
                {
                    sceneController = Manager.ManagerInstance.gameObject.AddComponent<ResistanceManageController>();
                    break;
                }
        }
    }


    public void LoadScene(Defines.Enums.Scenes type)
    {
        SceneManager.LoadScene((int)type);
    }
}
