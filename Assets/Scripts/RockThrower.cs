using UnityEngine;

public class RockThrower : MonoBehaviour
{
    public GameObject rockPrefab;
    public Camera playerCamera;
    public float throwForce = 10f;

    public bool isHoldingRock = false;

    public void PickupRock()
    {
        isHoldingRock = true;
    }

    public void ThrowRock()
    {
        if (isHoldingRock && rockPrefab != null && playerCamera != null)
        {
            GameObject thrownRock = Instantiate(rockPrefab, playerCamera.transform.position, playerCamera.transform.rotation);

            Rigidbody rb = thrownRock.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 throwDirection = playerCamera.transform.forward + Vector3.up * 0.2f;
                rb.AddForce(throwDirection * throwForce, ForceMode.Impulse);
            }
            isHoldingRock = false;
        }
    }
}
