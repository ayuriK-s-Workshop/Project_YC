using UnityEngine;

public class DialogueManager
{
    public BaseDialogue dialogue;


    public void Init()
    {
        switch (Manager.Scene.currentScene)
        {
            case Defines.Enums.Scenes.PawnshopScene:
                {
                    dialogue = new PawnshopDialogue();
                    (dialogue as PawnshopDialogue).Init();
                    break;
                }
        }
    }
}
