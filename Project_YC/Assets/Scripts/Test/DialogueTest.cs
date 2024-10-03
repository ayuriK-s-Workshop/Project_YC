using UnityEngine;

public class DialogueTest : MonoBehaviour
{
    public void TestTrigger()
    {
        (Manager.Game.sceneController as PawnshopController).characterController.UpdateCharacterData(90001);
        Manager.Dialogue.TriggerDialogue(Manager.Data.characterDB[90001].dialogueId, Manager.Data.characterDB[90001].itemId);
    }
}
