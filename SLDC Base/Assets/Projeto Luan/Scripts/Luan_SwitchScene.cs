using UnityEngine;
using UnityEngine.SceneManagement;

public class Luan_SwichScene : MonoBehaviour
{
    // Define a string variable to hold the name of the target scene
    public string targetSceneName;

    // This method is called when another collider enters the trigger collider attached to this GameObject
    void OnTriggerEnter(Collider other)
    {
        // Check if the collider belongs to the player (or any other specific tag if needed)
        if (other.CompareTag("Player"))
        {
            // Load the target scene
            SceneManager.LoadScene(targetSceneName);
        }
    }
}
