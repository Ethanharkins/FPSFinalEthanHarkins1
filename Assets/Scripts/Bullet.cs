using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // Adjust speed as necessary
    public float lifetime = 5f; // How long before the bullet gets destroyed automatically
    public ParticleSystem hitEffectPrefab; // Assign in the inspector

    private void Start()
    {
        // Apply initial forward momentum
        GetComponent<Rigidbody>().velocity = transform.forward * speed;

        // Destroy the bullet after 'lifetime' seconds to clean up
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Land"))
        {
            TriggerHitEffect();
            Destroy(gameObject); // Destroy the bullet
        }
    }

    void TriggerHitEffect()
    {
        if (hitEffectPrefab != null)
        {
            // Instantiate the particle system at the bullet's current position
            ParticleSystem hitEffectInstance = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
            // Destroy the particle effect GameObject after 2-3 seconds
            Destroy(hitEffectInstance.gameObject, 2f); // Adjust time as needed
        }
    }

}
