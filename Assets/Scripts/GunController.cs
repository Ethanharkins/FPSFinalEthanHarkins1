using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform gunModel;

    void Start()
    {
        if (gunModel == null)
        {
            Debug.LogError("Gun model not assigned!");
            return;
        }

        // Example: Position the gun correctly on start. You can adjust this as necessary.
        // This assumes the gun model's local position and rotation are set to zero in the prefab or model itself for simplicity.
        gunModel.localPosition = new Vector3(0.5f, -0.5f, 1f); // Adjust these values as needed to fit your camera view
        gunModel.localRotation = Quaternion.Euler(0, 0, 0);
    }

    // Example function for shooting, can be expanded based on game mechanics
    public void Shoot()
    {
        Debug.Log("Gun fired!");
        // Add shooting mechanics here, like raycasting from the camera forward and checking for hits
    }
    public class GunPositionAdjuster : MonoBehaviour
    {
        void Start()
        {
            // Example: Adjusting position and rotation to predefined values
            transform.localPosition = new Vector3(0.5f, -0.5f, 1f);
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Assuming "Fire1" is mapped to your shooting button in the Input Manager
        {
            Shoot();
        }
    }
}
