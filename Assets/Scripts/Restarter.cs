using System;
using UnityEngine;

public class Restarter : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        // Reload Scene
        if (other.gameObject.CompareTag("Player"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
}
