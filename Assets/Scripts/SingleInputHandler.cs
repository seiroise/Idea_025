using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleInputHandler : MonoBehaviour
{
    [SerializeField]
    private KeyCode _Key = KeyCode.A;

    protected virtual void Update()
    {
        if (Input.GetKeyDown(_Key))
        {
            OnKeyPressed();
        }
        if (Input.GetKey(_Key))
        {
            OnKeyHold();
        }
        if (Input.GetKeyUp(_Key))
        {
            OnKeyReleased();
        }
    }

    protected virtual void OnKeyPressed() { }
    protected virtual void OnKeyReleased() { }
    protected virtual void OnKeyHold() { }
}
