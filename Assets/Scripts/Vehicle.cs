using System;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    [SerializeField] private Rigidbody2D carRigidbody;
    [SerializeField] private Rigidbody2D frontTireRigidbody;
    [SerializeField] private Rigidbody2D backTireRigidbody;

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
            // TODO: Implement the logic to handle the vehicle entering the radar area
            Debug.Log(carRigidbody.velocity.x * 3.6f);
        }
    }
}
