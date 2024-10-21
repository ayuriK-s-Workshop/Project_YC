using System;
using UnityEngine;

public class InputManager
{
    public Action<Defines.Enums.KeyInputTypes, KeyCode> keyAction;

    public void Update()
    {
        if (keyAction != null)
        {
            // KeyDown
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                    keyAction.Invoke(Defines.Enums.KeyInputTypes.Down, KeyCode.Escape);
            }

            // KeyPress
            {

            }

            // KeyUp
            {

            }
        }
    }
}
