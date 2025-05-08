using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    public List<GameObject> controlledObjects;
    private bool isActivated = false;

    public void Activate()
    {
        if (isActivated) return;
        isActivated = true;
        Debug.Log("Lever activated!");

        foreach (GameObject obj in controlledObjects)
        {
            Door door = obj.GetComponent<Door>();
            if (door != null)
            {
                door.OpenDoor();
                continue;
            }

            Trap trap = obj.GetComponent<Trap>();
            if (trap != null)
            {
                trap.DisarmTrap();
            }
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Rock"))
        {
            Activate();
        }
    }
}

