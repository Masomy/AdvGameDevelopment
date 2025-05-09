using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public int damageAmount = 100;
    private bool isActive = true;

    private void OnCollisionEnter(Collision collision)
    {
        if (!isActive) return;

        if (collision.gameObject.CompareTag("Rock"))
        {
            DisarmTrap();
            Destroy(collision.gameObject);
        }

    }

    public void HitPlayer(GameObject player)
    {
        if (!isActive) return;

        PlayerStats stats = player.GetComponent<PlayerStats>();
        if (stats != null)
        {
            stats.ModifyHealth(-damageAmount);
            Debug.Log("Player touched trap and took damage.");
        }
    }

    public void DisarmTrap()
    {
        isActive = false;
        Debug.Log("Trap has been disarmed!");
        // Optional: play an animation, change material, disable collider, etc.

        Destroy(gameObject);
    }
}