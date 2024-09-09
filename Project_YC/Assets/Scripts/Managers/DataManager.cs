using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class DataManager
{
    public Dictionary<int, CharacterSO> characterDB = new Dictionary<int, CharacterSO>();
    public Dictionary<int, DialogueSO> dialogueDB = new Dictionary<int, DialogueSO>();
    public Dictionary<int, InterchangeableItemSO> interchangeableItemDB = new Dictionary<int, InterchangeableItemSO>();
    public void Init()
    {
        foreach (CharacterSO characterData in Resources.LoadAll<CharacterSO>("Datas/Characters"))
        {
            characterDB.Add(characterData.id, characterData);
        }

        foreach (DialogueSO dialogueData in Resources.LoadAll<DialogueSO>("Datas/Dialogues"))
        {
            dialogueDB.Add(dialogueData.id, dialogueData);
        }

        foreach (InterchangeableItemSO itemData in Resources.LoadAll<InterchangeableItemSO>("Datas/Items"))
        {
            interchangeableItemDB.Add(itemData.id, itemData);
        }
    }
}
