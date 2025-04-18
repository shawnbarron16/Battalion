using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool isUIOpen {get; private set;} = false;

    public static void SetUIOpen(bool open)
    {
        isUIOpen = open;

        Cursor.lockState = open ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = open;
    }
}
