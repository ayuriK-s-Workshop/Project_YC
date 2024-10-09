using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public Dictionary<int, CharacterSO> characterDB = new Dictionary<int, CharacterSO>();
    public Dictionary<int, DialogueSO> dialogueDB = new Dictionary<int, DialogueSO>();
    public Dictionary<int, InterchangeableItemSO> interchangeableItemDB = new Dictionary<int, InterchangeableItemSO>();
    public void Init()
    {
        foreach (CharacterSO characterData in Resources.LoadAll<CharacterSO>(Values.Directory.DIR_DATA_CHARACTER))
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
