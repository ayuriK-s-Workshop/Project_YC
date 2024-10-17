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
}
