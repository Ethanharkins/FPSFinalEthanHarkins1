using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform shootingPoint; // The point from which bullets are shot, should be a child of the camera or oriented with it
    public GameObject bulletPrefab; // Assign your bullet prefab
    public Camera playerCamera; // Reference to the player's camera to align bullets with the camera's forward direction

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Default fire button
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        if (bulletPrefab != null && shootingPoint != null)
        {
            // Instantiate the bullet at the shooting point and align it with the shooting point's (and therefore the camera's) forward direction
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.LookRotation(playerCamera.transform.forward));
            Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
            if (bulletRb != null)
            {
                // Apply initial velocity in the forward direction
                bulletRb.velocity = shootingPoint.forward * 20f; // Adjust the speed as necessary
            }
        }
    }
}
