using UnityEngine;

[CreateAssetMenu(fileName = "CustomerData", menuName = "ScriptableObject/CharacterData", order = int.MinValue)]
public class CustomerSO : ScriptableObject
{
    public int id;
    public string name;
    public Defines.Enums.CustomerPersonality personality;
    public int dialogueId;
    public int itemId;
}
