using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterData", menuName = "ScriptableObject/CharacterData", order = int.MinValue)]
public class CharacterSO : ScriptableObject
{
    public int id;
    public string name;
    public Defines.Enums.CharacterPersonality personality;
    public InterchangeableItemSO item;
}
