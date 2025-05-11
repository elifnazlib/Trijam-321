using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject realVehicle;
    [SerializeField] private GameObject ghostVehicle;

    public void StartSimulation()
    {
        ghostVehicle.SetActive(false);
        realVehicle.SetActive(true);
    }
    
    public void RestartScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
    
    public void LoadNextScene()
    {
        int currentSceneIndex = UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex < UnityEngine.SceneManagement.SceneManager.sceneCountInBuildSettings)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0); // Loop back to the first scene
        }
    }
}
