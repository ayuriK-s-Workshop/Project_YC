using UnityEngine;

public class DialogueTest : MonoBehaviour
{
    public void TestTrigger()
    {
        Manager.Dialogue.TriggerDialogue(Manager.Data.characterDB[90001].dialogueId, Manager.Data.characterDB[90001].itemId);
    }

    public void TestAccept()
    {
        Manager.Dialogue.AcceptTrade();
    }

    public void TestDeny()
    {
        Manager.Dialogue.DenyTrade();
    }
}
