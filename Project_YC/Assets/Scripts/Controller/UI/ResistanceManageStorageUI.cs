using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResistanceManageStorageUI : MonoBehaviour
{
    private GameObject _storageItemPrefab;
    void Start()
    {
        _storageItemPrefab = Resources.Load("Prefabs/UI/Item") as GameObject;

        Transform storageInstancePoint = transform.Find("ScrollView/Viewport/Content");
        foreach (int itemId in Manager.Game.playerStorage.Keys)
        {
            GameObject go = Instantiate(_storageItemPrefab, storageInstancePoint);
            go.transform.Find("Image").GetComponent<Image>().sprite = Manager.Data.interchangeableItemDB[itemId].texture;
            go.transform.Find("Count").GetComponent<TextMeshProUGUI>().text = $"{Manager.Game.playerStorage[itemId]}";
        }
        gameObject.SetActive(false);
    }
}
