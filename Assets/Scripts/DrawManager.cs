using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

// DrawManager is responsible for managing the drawing of lines in the game.
// It handles the creation and destruction of line objects based on user input.
// The class limits the number of vertices that can be drawn to 200 and provides
// methods to increase and retrieve the total vertex count.
public class DrawManager : MonoBehaviour
{
    private Camera _cam; // Reference to the main camera
    [SerializeField] private Line _linePrefab; // Prefab for the line object
    private Line _currentLine; // Current line being drawn
    public const float RESOLUTION = 0.1f; // Resolution for the line drawing
    private int totalVertices = 0; // Total number of vertices drawn
    [SerializeField] public int maxVertices = 200; // Maximum number of vertices allowed
    // [SerializeField] private TextMeshProUGUI maxVerticesText;
    [SerializeField] private Slider maxVerticesSlider;

    void Start()
    {
        _cam = Camera.main; // Get the main camera
        // maxVerticesText.text = maxVertices.ToString();
        maxVerticesSlider.maxValue = maxVertices; // Set the maximum value of the slider
        maxVerticesSlider.value = maxVertices; // Set the initial value of the slider
    }

    void Update()
    {
        Vector2 mousePos = _cam.ScreenToWorldPoint(Input.mousePosition); // Get the mouse position in world coordinates
        
        if (GetTotalVertexCount() < maxVertices) // Limit the number of vertices to 200
        {
            if (Input.GetMouseButtonDown(0)) 
                _currentLine = Instantiate(_linePrefab, mousePos, Quaternion.identity); // Create a new line at the mouse position
            
            if (Input.GetMouseButton(0)) 
                _currentLine.SetPosition(mousePos); // Set the position of the current line to the mouse position
            
            if (Input.GetMouseButtonUp(0) && _currentLine.GetPointsCount() < 2) 
                Destroy(_currentLine.gameObject); // Destroy the line if it has less than 2 points when the mouse button is released
        }
    }

    // Method to increase the total vertex count
    public void IncreaseVertexCount()
    {
        totalVertices++;
        // maxVerticesText.text = (maxVertices - totalVertices).ToString(); // Update the remaining vertices text
        maxVerticesSlider.value--; // Update the slider value
    }

    // Method to get the total vertex count
    public int GetTotalVertexCount()
    {
        return totalVertices;
    }
}
