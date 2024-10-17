using UnityEngine;

public class ResistanceManageController : SceneController
{
    private GameObject _storageUI;
    private GameObject _recruitUI;

    void Start()
    {
        {
            _storageUI = Manager.UI.GetUIObject((int)Defines.SceneComponents.ResistanceManageUI.StorageUI);
            _recruitUI = Manager.UI.GetUIObject((int)Defines.SceneComponents.ResistanceManageUI.RecruitUI);
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
