using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int score = 0;
    public int health = 100;

    public int keys = 0;

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }

    public void ModifyHealth(int amount)
    {
        health += amount;
        health = Mathf.Clamp(health, 0, 100);
        Debug.Log("Health: " + health);
    }

    public void AddKey(int amount)
    {
        keys += amount;
        Debug.Log("Keys: " + keys);
    }
}
