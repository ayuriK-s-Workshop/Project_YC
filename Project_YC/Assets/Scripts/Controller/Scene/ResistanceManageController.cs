using UnityEngine;

public class ResistanceManageController : SceneController
{
    private GameObject _storageUI;

    void Start()
    {
        {
            _storageUI = Manager.UI.GetUIObject((int)Defines.SceneComponents.ResistanceManageUI.StorageUI);
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
