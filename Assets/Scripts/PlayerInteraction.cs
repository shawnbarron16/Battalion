using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 3f;
    public Camera playerCamera;
    public TextMeshProUGUI interactionPrompt;

    private Interactable currentInteractable = null;

    // Update is called once per frame
    void Update()
    {
        //When E is pressed send out a ray forward from the camera
        if(Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }

        //Send out a ray to detect interactables
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        //Check if the ray hit something interactable within the interact range
        if(Physics.Raycast(ray, out hit, interactRange))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();
            if(interactable != null)
            {
                //Show the interact prompt UI
                interactionPrompt.text = interactable.interactPromptText;
                interactionPrompt.gameObject.SetActive(true);
                currentInteractable = interactable;
            }
            else
            {
                interactionPrompt.gameObject.SetActive(false);
                currentInteractable = null;
            }
        }
        else
        {
            interactionPrompt.gameObject.SetActive(false);
            currentInteractable = null;
        }
    }
}
