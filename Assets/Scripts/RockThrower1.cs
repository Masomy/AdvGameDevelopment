using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockThrower : MonoBehaviour
{
    public GameObject rockPrefab;
    public Camera playerCamera;
    public Transform throwPoint;
    public float throwForce = 10f;
    public LineRenderer trajectoryLine;
    public int trajectoryPoints = 30;
    public float timeBetweenPoints = 0.1f;

    public bool isHoldingRock = false;

    private bool isChargingThrow = false;

    void Update()
    {
        if (isHoldingRock)
        {
            if (Input.GetMouseButton(0))
            {
                isChargingThrow = true;
                ShowTrajectory();
            }
            else if (Input.GetMouseButtonUp(0))
            {
                isChargingThrow = false;
                trajectoryLine.enabled = true;
                ThrowRock();
            }
        }
    }

    public void PickupRock()
    {
        isHoldingRock = true;
    }

    public void ThrowRock()
    {
        if (rockPrefab != null && throwPoint != null)
        {
            GameObject thrownRock = Instantiate(rockPrefab, throwPoint.position, throwPoint.rotation);

            Rigidbody rb = thrownRock.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 throwDirection = playerCamera.transform.forward + Vector3.up * 0.2f;
                rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
            }
        }
        isHoldingRock = true;
    }

    private void ShowTrajectory()
    {
        if (trajectoryLine == null || rockPrefab == null || throwPoint == null)
            return;

        trajectoryLine.enabled = true;
        trajectoryLine.positionCount = trajectoryPoints;

        Vector3 startPosition = throwPoint.position;
        Vector3 startVelocity = (playerCamera.transform.forward + Vector3.up * 0.2f) * throwForce;

        for (int i = 0; i < trajectoryPoints; i++)
        {
            float time = i * timeBetweenPoints;
            Vector3 position = startPosition + startVelocity * time + 0.5f * Physics.gravity * time * time;
            trajectoryLine.SetPosition(i, position);
        }
    }
}
