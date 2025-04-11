using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    //Override default interact text
    void Awake()
    {
        interactPromptText = "Press E to open door";
    }
    //Open the door
    public override void Interact()
    {
        transform.Rotate(0, 90, 0);
    }
}
