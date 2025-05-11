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
}
