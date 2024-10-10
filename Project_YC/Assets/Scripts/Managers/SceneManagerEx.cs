using System;
using UnityEngine.SceneManagement;

public class SceneManagerEx
{
    public Defines.Enums.Scenes currentScene;


    public void Init()
    {
        UpdateCurrentScene();
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
    }


    public void LoadScene(Defines.Enums.Scenes type)
    {
        SceneManager.LoadScene((int)type);
    }
}
