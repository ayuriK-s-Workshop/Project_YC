using UnityEngine;

public class DialogueManager
{
    public PawnshopDialogueManager pawnshopDialogue;


    public void Init()
    {
        switch (Manager.Scene.currentScene)
        {
            case Defines.Enums.Scenes.PawnshopScene:
                {
                    pawnshopDialogue = new PawnshopDialogueManager();
                    pawnshopDialogue.Init();
                    break;
                }
        }
    }
}
