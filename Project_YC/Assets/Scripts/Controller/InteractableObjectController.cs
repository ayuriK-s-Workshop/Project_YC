using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObjectController : MonoBehaviour
{
    private bool _isClickReady = false;

    private void OnMouseDown()
    {
        _isClickReady = true;
    }

    private void OnMouseUp()
    {
        if (_isClickReady)
        {
            if (Manager.Scene.sceneController.interactableObject != null && !Manager.UI.IsUIInstanceExits())
                Manager.Scene.sceneController.interactableObject.Invoke(this);
        }
    }

    private void OnMouseExit()
    {
        _isClickReady = false;
    }
}
