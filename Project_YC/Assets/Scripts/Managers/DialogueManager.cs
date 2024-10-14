using UnityEngine;

public class DialogueManager
{
    public BaseDialogue pawnshopDialogue;


    public void Init()
    {
        switch (Manager.Scene.currentScene)
        {
            case Defines.Enums.Scenes.PawnshopScene:
                {
                    pawnshopDialogue = new PawnshopDialogue();
                    (pawnshopDialogue as PawnshopDialogue).Init();
                    break;
                }
        }
    }
}
