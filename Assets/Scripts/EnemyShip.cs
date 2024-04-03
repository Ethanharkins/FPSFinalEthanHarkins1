using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public GameObject bulletPrefab; // Assign in inspector
    public Transform shootPoint; // Assign a point from where bullets will be instantiated
    public float shootingInterval = 2f; // Time between shots
    public float bulletSpeed = 20f; // Speed of the bullet
    public float followSpeed = 5f; // Speed at which enemy follows the player
    public float heightAbovePlayer = 10f; // Height above the player

    private Transform player;
    private float shootingTimer;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        shootingTimer = shootingInterval; // Initialize timer
    }

    void Update()
    {
        // Follow player horizontally
        Vector3 newPosition = new Vector3(player.position.x, player.position.y + heightAbovePlayer, player.position.z);
        transform.position = Vector3.Lerp(transform.position, newPosition, followSpeed * Time.deltaTime);

        // Shooting logic
        shootingTimer -= Time.deltaTime;
        if (shootingTimer <= 0)
        {
            Shoot();
            shootingTimer = shootingInterval;
        }
    }

    void Shoot()
    {
        if (bulletPrefab != null && shootPoint != null)
        {
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, Quaternion.identity);
            Vector3 shootingDirection = (player.position - shootPoint.position).normalized;
            bullet.GetComponent<Rigidbody>().velocity = shootingDirection * bulletSpeed;
        }
    }
}
