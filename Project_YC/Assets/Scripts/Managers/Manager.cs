using UnityEngine;

public class Manager : MonoBehaviour
{
    static public Manager ManagerInstance;

    static private DataManager _data = new DataManager();
    static private DialogueManager _dialogue = new DialogueManager();
    static private UIManager _ui = new UIManager();
    static private GameManager _game = new GameManager();
    static private SceneManagerEx _scene = new SceneManagerEx();

    static public DataManager Data { get { return _data; } }
    static public DialogueManager Dialogue {  get { return _dialogue; } }
    static public UIManager UI { get { return _ui; } }
    static public GameManager Game { get { return _game; } }
    static public SceneManagerEx Scene { get { return _scene; } }

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

        /* 초기화 순서는 코드 구조에 따라 정해둔 것이므로 임의 변경 절대 금지 */
        Data.Init();
        Scene.Init();
        UI.Init();
        Dialogue.Init();
        Game.Init();
    }
}
