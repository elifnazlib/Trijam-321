using TMPro;
using UnityEngine;

public class SpeedMeter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private Rigidbody2D carRigidbody;

    private void Update()
    {
        speedText.text = Mathf.Abs(carRigidbody.velocity.x * 3.6f).ToString("F2"); // Display the speed in m/s
    }
}
