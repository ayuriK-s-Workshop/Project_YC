using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResistanceManageController : SceneController
{
    private GameObject _storageUI;
    private GameObject _storageItemPrefab;

    void Start()
    {
        // StorageUI Initialize
        {
            _storageUI = Manager.UI.GetUIObject((int)Defines.SceneComponents.ResistanceManageUI.StorageUI);
            _storageItemPrefab = Resources.Load("Prefabs/UI/Item") as GameObject;
            
            Transform storageInstancePoint  = _storageUI.transform.Find("ScrollView/Viewport/Content");
            foreach (InterchangeableItemSO item in Manager.Game.playerStorage)
            {
                GameObject go = Instantiate(_storageItemPrefab, storageInstancePoint);
                go.transform.Find("Image").GetComponent<Image>().sprite = item.texture;
                go.transform.Find("Count").GetComponent<TextMeshProUGUI>().text = "1";
            }
            _storageUI.SetActive(false);
        }

        interactableObject += ObjectInteractHandler;
    }

    override protected void ObjectInteractHandler(UnityEngine.Object obj)
    {
        switch (obj.name)
        {
            case "Storage":
                {
                    _storageUI.SetActive(true);
                    break;
                }
        }
    }
}
