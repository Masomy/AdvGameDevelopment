using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public int scoreValue = 0;
    public int healthValue = 0;
    public bool isRock = false;

    public bool isKey = false;

    public void Interact(GameObject player)
    {
        PlayerStats playerStats = player.GetComponent<PlayerStats>();
        if (playerStats == null) return;

        if (scoreValue != 0)
            playerStats.AddScore(scoreValue);

        if (healthValue != 0)
            playerStats.ModifyHealth(healthValue);

        if (isKey)
            playerStats.AddKey(1);

        if (isRock)
        {
            RockThrower thrower = player.GetComponentInChildren<RockThrower>();
            if (thrower != null && !thrower.isHoldingRock)
            {
                thrower.PickupRock();
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
