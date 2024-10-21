using UnityEngine;

public class ResistanceManageController : SceneController
{
    private GameObject _storageUI;
    private GameObject _recruitUI;
    private GameObject _eventsUI;
    private GameObject _mapUI;

    void Start()
    {
        {
            _storageUI = Manager.UI.GetUIObject((int)Defines.SceneComponents.ResistanceManageUI.StorageUI);
            _recruitUI = Manager.UI.GetUIObject((int)Defines.SceneComponents.ResistanceManageUI.RecruitUI);
            _eventsUI = Manager.UI.GetUIObject((int)Defines.SceneComponents.ResistanceManageUI.EventsUI);
            _mapUI = Manager.UI.GetUIObject((int)Defines.SceneComponents.ResistanceManageUI.MapUI);
        }

        interactableObject += ObjectInteractHandler;
        Manager.Input.keyAction += KeyInputHandler;
    }

    override protected void ObjectInteractHandler(UnityEngine.Object obj)
    {
        base.ObjectInteractHandler(obj);

        switch (obj.name)
        {
            case "Storage":
                {
                    Manager.UI.ActivateUIInstace(_storageUI);
                    break;
                }
            case "Recruit":
                {
                    Manager.UI.ActivateUIInstace(_recruitUI);
                    break;
                }
            case "Events":
                {
                    Manager.UI.ActivateUIInstace(_eventsUI);
                    break;
                }
            case "Map":
                {
                    Manager.UI.ActivateUIInstace(_mapUI);
                    break;
                }
        }
    }

    private void KeyInputHandler(Defines.Enums.KeyInputTypes type, KeyCode keyCode)
    {
        switch (type)
        {
            case Defines.Enums.KeyInputTypes.Down:
                {
                    switch (keyCode)
                    {
                        case KeyCode.Escape:
                            {
                                Manager.UI.DeactivateUIInstance();
                                break;
                            }
                    }
                    break;
                }
        }
    }
}
