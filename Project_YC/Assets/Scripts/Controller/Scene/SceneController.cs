using System;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    public Action<UnityEngine.Object> interactableObject;

    virtual protected void ObjectInteractHandler(UnityEngine.Object obj) { }
}
