using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockPointVisual : MonoBehaviour
{
    public RockThrower rockThrower;

    void Update()
    {
        if (rockThrower != null)
        {
            gameObject.SetActive(rockThrower.isHoldingRock);
        }
    }
}
