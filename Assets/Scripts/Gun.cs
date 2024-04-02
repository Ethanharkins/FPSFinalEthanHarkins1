using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform shootingPoint; // Assign an empty GameObject as the shooting point
    public GameObject bulletPrefab; // Assign your bullet prefab

    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Default fire button
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && shootingPoint != null)
        {
            // Instantiate bullet prefab at the shooting point position and rotation
            Instantiate(bulletPrefab, shootingPoint.position, shootingPoint.rotation);
        }
    }
}
