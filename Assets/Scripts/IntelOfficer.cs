using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelOfficer : Interactable
{
    //Override default interact text
    void Awake()
    {
        interactPromptText = "Press E to talk to\ntalk to the intel officer";
    }
    //Open the door
    public override void Interact()
    {
        
    }
}
