using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InterchangeableItemData", menuName = "ScriptableObject/InterchangeableItemData", order = int.MinValue)]
public class InterchangeableItemSO : ScriptableObject
{
    public int id;
    public string name;
}
