using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float interactRange = 3f;
    public Camera playerCamera;
    public LayerMask interactableLayer;
    public GameObject interactionPromptUI;

    private InteractableObject currentInteractable;

    private void Update()
    {
        HandleRaycast();

        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            Lever lever = currentInteractable.GetComponent<Lever>();
            if (lever != null)
            {
                lever.Activate();
            }
            else
            {
                currentInteractable.Interact(gameObject);

            }

            currentInteractable = null;
            interactionPromptUI.SetActive(false);
        }
    }

    void HandleRaycast()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange, interactableLayer))
        {
            InteractableObject interactable = hit.collider.GetComponent<InteractableObject>();
            if (interactable != null)
            {
                currentInteractable = interactable;
                interactionPromptUI.SetActive(true);
                return;
            }
        }

        currentInteractable = null;
        interactionPromptUI.SetActive(false);
    }
}
