using UnityEngine;

public class DialogueTest : MonoBehaviour
{
    public void TestTrigger()
    {
        Manager.DialogueManager.TriggerDialogue(Manager.DataManager.characterDB[90001].dialogueId, Manager.DataManager.characterDB[90001].itemId);
    }

    public void TestNext()
    {
        Manager.DialogueManager.ChangeDialogue();
    }

    public void TestAccept()
    {
        Manager.DialogueManager.AcceptTrade();
    }

    public void TestDeny()
    {
        Manager.DialogueManager.DenyTrade();
    }
}
