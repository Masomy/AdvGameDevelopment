using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damageAmount = 20;
    private bool isActive = true;

    private void OnTriggerEnter(Collider other)
    {
        if (!isActive) return;

        PlayerStats player = other.GetComponent<PlayerStats>();
        if (player != null)
        {
            player.ModifyHealth(-damageAmount);
            Debug.Log("Player triggered trap and took damage.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (!isActive) return;

        if (collision.gameObject.CompareTag("Rock"))
        {
            DisarmTrap();
            Destroy(collision.gameObject);
        }
    }

    public void DisarmTrap()
    {
        isActive = false;
        Debug.Log("Trap has been disarmed!");
        // Optional: play an animation, change material, disable collider, etc.
    }
}
