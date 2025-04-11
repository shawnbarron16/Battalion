using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntelCenter : Interactable
{
    public GameObject intelUIPanel;
    public MonoBehaviour[] playerControlScripts;

    //Override default interact text
    void Awake()
    {
        interactPromptText = "Press E to access\nthe intel desk";
    }

    void Start()
    {
        if(intelUIPanel != null)
        {
            intelUIPanel.SetActive(false);
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    //Activate the intel UI
    public override void Interact()
    {
        if(intelUIPanel != null)
        {
            //Toggle the active state
            bool isActive = intelUIPanel.activeSelf;
            intelUIPanel.SetActive(!isActive);

            //Unlock and show cursor and disable player control script
            if(!isActive)
            {
                Debug.Log("Intel interface opened.");

                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;

                if(playerControlScripts != null)
                {
                    foreach(MonoBehaviour script in playerControlScripts)
                    {
                        script.enabled = false;
                    }
                }
            }
            //Lock and hide the cursor and enable player control script
            else
            {
                Debug.Log("Intel interface closed.");

                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                if(playerControlScripts != null)
                {
                    foreach(MonoBehaviour script in playerControlScripts)
                    {
                        script.enabled = true;
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("Intel UI panel not assigned in inspector");
        }
    }

    public void ClosePanel()
    {
        if(intelUIPanel != null)
        {
            intelUIPanel.SetActive(false);

            //Re-lock and hide the cursor and enable player movement
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            if(playerControlScripts != null)
            {
                foreach(MonoBehaviour script in playerControlScripts)
                {
                    script.enabled = true;
                }
            }
        }
    }

    void Update()
    {
        if(intelUIPanel != null && intelUIPanel.activeSelf)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                ClosePanel();
            }
        }
    }
}
