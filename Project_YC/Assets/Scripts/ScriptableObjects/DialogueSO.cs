using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObject/DialogueData", order = int.MinValue)]
public class DialogueSO : ScriptableObject
{
    public int id;

    public List<Defines.Classes.DialogueText> acceptText;
    public List<Defines.Classes.DialogueText> denyText;
    public List<Defines.Classes.DialogueText> negoText;
    public List<Defines.Classes.DialogueText> lowCostText;

    public List<Defines.Classes.DialogueText> dialogues;
}
