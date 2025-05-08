using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Animator animator;  // Optional: drag the door's Animator here
    public bool isOpen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (isOpen) return;

        PlayerStats stats = other.GetComponent<PlayerStats>();
        if (stats != null && stats.keys > 0)
        {
            stats.keys--;
            Debug.Log("Key used to open door. Keys left: " + stats.keys);
            OpenDoor();
        }
    }

    public void OpenDoor()
    {
        isOpen = true;

        if (animator != null)
        {
            animator.SetTrigger("Open");
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
