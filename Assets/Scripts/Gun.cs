using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform shootingPoint;
    public GameObject bulletPrefab;
    public Camera playerCamera;

    void Update()
    {
        AimGun();

        if (Input.GetButtonDown("Fire1"))
        {
            ShootBullet();
        }
    }

    void AimGun()
    {
        // Directly use the camera's forward direction for aiming.
        // This assumes the gun's position is properly set relative to the camera.
        transform.forward = playerCamera.transform.forward;
    }

    void ShootBullet()
    {
        if (bulletPrefab != null && shootingPoint != null)
        {
            // Instantiate the bullet at the shooting point
            GameObject bullet = Instantiate(bulletPrefab, shootingPoint.position, Quaternion.identity);
            // Align bullet's forward direction with the camera's (and hence the gun's) forward direction at the moment of shooting.
            bullet.transform.forward = playerCamera.transform.forward;
        }
    }
}
