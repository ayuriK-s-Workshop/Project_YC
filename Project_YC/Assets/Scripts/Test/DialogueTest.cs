using UnityEngine;

public class DialogueTest : MonoBehaviour
{
    public void TestTrigger()
    {
        Manager.DialogueManager.TriggerDialogue(92001);
    }

    public void TestNext()
    {
        Manager.DialogueManager.ChangeDialogue();
    }
}
