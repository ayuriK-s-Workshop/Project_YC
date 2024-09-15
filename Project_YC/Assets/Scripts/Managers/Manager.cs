using UnityEngine;

public class Manager : MonoBehaviour
{
    static public Manager ManagerInstance;

    static private DataManager _dataManager = new DataManager();
    static private DialogueManager _dialogueManager = new DialogueManager();
    static private UIManager _uiManager = new UIManager();
    static private GameManager _gameManager = new GameManager();

    static public DataManager DataManager { get { return _dataManager; } }
    static public DialogueManager DialogueManager {  get { return _dialogueManager; } }
    static public UIManager UIManager { get { return _uiManager; } }
    static public GameManager GameManager { get { return _gameManager; } }

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        if (ManagerInstance != null)
        {
            Destroy(this);
            return;
        }

        ManagerInstance = this;
        DontDestroyOnLoad(gameObject);

        DataManager.Init();
        UIManager.Init();
        DialogueManager.Init();
        GameManager.Init();
    }
}
