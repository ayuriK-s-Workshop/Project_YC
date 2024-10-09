using UnityEngine;

[CreateAssetMenu(fileName = "InterchangeableItemData", menuName = "ScriptableObject/InterchangeableItemData", order = int.MinValue)]
public class InterchangeableItemSO : ScriptableObject
{
    public int id;
    public string name;
    public int actualValue;
    public Sprite texture;
}
