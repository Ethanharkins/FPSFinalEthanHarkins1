using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float destroyTime = 2f; // Time after which bullet gets destroyed automatically
    public ParticleSystem hitEffect; // Assign in inspector

    private void Start()
    {
        // Give the bullet an initial forward momentum
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        Destroy(gameObject, destroyTime); // Destroys bullet after a set amount of time
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hitEffect != null)
        {
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
        Destroy(gameObject); // Destroy bullet on collision
    }
}
