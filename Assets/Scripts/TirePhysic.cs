using UnityEngine;

public class TirePhysic : MonoBehaviour
{
    [SerializeField] private Rigidbody2D frontTireRigidbody;
    [SerializeField] private Rigidbody2D backTireRigidbody;

    private void FixedUpdate()
    {
        // Add torque to the tires based on its velocity
        frontTireRigidbody.AddTorque(frontTireRigidbody.velocity.x * Time.fixedDeltaTime); 
        backTireRigidbody.AddTorque(backTireRigidbody.velocity.x * Time.fixedDeltaTime); 
    }
}
