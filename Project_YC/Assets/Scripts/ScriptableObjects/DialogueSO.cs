using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueData", menuName = "ScriptableObject/DialogueData", order = int.MinValue)]
public class DialogueSO : ScriptableObject
{
    public int id;

    public List<Defines.Classes.DialogueText> acceptTradeText;
    public List<Defines.Classes.DialogueText> denyTradeText;
    public List<Defines.Classes.DialogueText> acceptNegoText;
    public List<Defines.Classes.DialogueText> denyNegoText;

    public List<Defines.Classes.DialogueText> dialogues;
}
