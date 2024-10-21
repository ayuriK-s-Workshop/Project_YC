using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public Dictionary<int, CustomerSO> characterDB = new Dictionary<int, CustomerSO>();
    public Dictionary<int, DialogueSO> dialogueDB = new Dictionary<int, DialogueSO>();
    public Dictionary<int, InterchangeableItemSO> interchangeableItemDB = new Dictionary<int, InterchangeableItemSO>();
    public void Init()
    {
        foreach (CustomerSO characterData in Resources.LoadAll<CustomerSO>(Values.Directory.DIR_DATA_CHARACTER_CUSTOMER))
        {
            characterDB.Add(characterData.id, characterData);
        }

        foreach (DialogueSO dialogueData in Resources.LoadAll<DialogueSO>(Values.Directory.DIR_DATA_DIALOGUE))
        {
            dialogueDB.Add(dialogueData.id, dialogueData);
        }

        foreach (InterchangeableItemSO itemData in Resources.LoadAll<InterchangeableItemSO>(Values.Directory.DIR_DATA_ITEM))
        {
            interchangeableItemDB.Add(itemData.id, itemData);
        }
    }
}
