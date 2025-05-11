using System.Collections.Generic;
using UnityEngine;

// Line is a class that represents a line drawn in the game using a LineRenderer component.
// It provides methods to set the position of the line, check if a new point can be appended,
// and get the total number of points in the line.
// The class also interacts with the DrawManager to manage the total vertex count.
// The line is limited to a maximum of 200 vertices, and the distance between points must be greater than a defined resolution.
// The class is attached to a GameObject in the scene and uses the LineRenderer component to render the line.
public class Line : MonoBehaviour
{
    [SerializeField] private LineRenderer _renderer; // Reference to the LineRenderer component
    [SerializeField] private EdgeCollider2D _collider; // Reference to the EdgeCollider2D component
    private readonly List<Vector2> _points = new List<Vector2>(); // List to store the points of the line
    private DrawManager drawManager; // Reference to the DrawManager script

    void Awake()
    {
        drawManager = (DrawManager)FindFirstObjectByType(typeof(DrawManager)); // Find the DrawManager in the scene
    }

    void Start()
    {
        _collider.transform.position = Vector3.zero; // Set the position of the collider to zero
    }

    public void SetPosition(Vector2 pos)
    {
        if (CanAppend(pos) == false) return; // Check if we can append a new point

        if(drawManager.GetTotalVertexCount() >= drawManager.maxVertices) return; // Limit the number of vertices to 200

        _points.Add(pos); // Add the new point to the list of points
        _renderer.positionCount++; // Increase the number of points in the line renderer
        _renderer.SetPosition(_renderer.positionCount - 1, pos); // Set the position of the new point

        _collider.points = _points.ToArray(); // Update the collider points to match the line points

        drawManager.IncreaseVertexCount(); // Increase the total vertex count in the DrawManager
    }

    private bool CanAppend(Vector2 pos)
    {
        // If there are no points, we can always append a new one
        if (_renderer.positionCount == 0) return true;


        // Check if the distance from the last point to the new point is greater than the resolution
        return Vector2.Distance(_renderer.GetPosition(_renderer.positionCount - 1), pos) > DrawManager.RESOLUTION;
    }

    public int GetPointsCount()
    {
        return _renderer.positionCount; // Return the number of points in the line renderer
    }
}
