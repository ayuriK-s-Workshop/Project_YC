using UnityEngine;

[CreateAssetMenu(fileName = "CrewData", menuName = "ScriptableObject/CrewData", order = int.MinValue)]
public class CrewSO : ScriptableObject
{
    public int id;
    public string name;
    public int[] abilities = new int[4];
    public int mentality;
    public int reliability;
    public Defines.Enums.CrewPositivePersonality posPersonality;
    public Defines.Enums.CrewNegativePersonality negPersonality;
}
