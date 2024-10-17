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
        foreach (InterchangeableItemSO item in Manager.Game.playerStorage)
        {
            GameObject go = Instantiate(_storageItemPrefab, storageInstancePoint);
            go.transform.Find("Image").GetComponent<Image>().sprite = item.texture;
            go.transform.Find("Count").GetComponent<TextMeshProUGUI>().text = "1";
        }
        gameObject.SetActive(false);
    }
}
