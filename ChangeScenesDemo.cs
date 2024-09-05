using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenesDemo : MonoBehaviour
{
    [SerializeField] private SceneReference toScene;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Entered Collider!");
            if (!string.IsNullOrEmpty(toScene.SceneName))
            {
                SceneManager.LoadScene(toScene.SceneName);
            }
        }
    }
}
