using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu") // Replace with your actual main menu scene name
        {
            Destroy(gameObject); // Destroy the GameManager when back in the main menu
        }
    }
}
