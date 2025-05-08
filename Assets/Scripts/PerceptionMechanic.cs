using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionMechanic : MonoBehaviour
{
    public Transform player;
    public float defaultRange = 5f;
    public float crouchRange = 8f;

    private Renderer objRenderer;
    private bool isCrouching;
    private PlayerMovement playerScript;

    void Start()
    {
        objRenderer = GetComponent<Renderer>();
        playerScript = player.GetComponent<PlayerMovement>();

        if (objRenderer == null)
        {
            Debug.LogError("No Renderer found! Ensure the object has a MeshRenderer.");
        }

        // Hide the object initially
        objRenderer.enabled = false;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        isCrouching = Input.GetKey(KeyCode.LeftControl);

        float visibilityRange = isCrouching ? crouchRange : defaultRange;

        objRenderer.enabled = distance <= visibilityRange;
    }
}