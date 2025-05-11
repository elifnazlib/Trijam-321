using System;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D carRigidbody;
    [SerializeField] private Rigidbody2D frontTireRigidbody;
    [SerializeField] private Rigidbody2D backTireRigidbody;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject restarters;

    private void FixedUpdate()
    {
        // Add torque to the tires based on its velocity
        frontTireRigidbody.AddTorque(frontTireRigidbody.velocity.x * Time.fixedDeltaTime); 
        backTireRigidbody.AddTorque(backTireRigidbody.velocity.x * Time.fixedDeltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Radar"))
        {
            restarters.SetActive(false);
            gameOverPanel.SetActive(true); // Show the game over panel
            Debug.Log(carRigidbody.velocity.x * 3.6f);
            // TODO: Destroy the vehicle after some time if necessary
        }
    }
}
