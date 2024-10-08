using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(LineRenderer))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of the player
    public float swipeThreshold = 50f; // Minimum swipe distance
    private Vector3 moveDirection = Vector3.left; // Initial movement direction
    private LineRenderer lineRenderer;  // LineRenderer for drawing the trail
    private List<Vector3> trailPoints = new List<Vector3>(); // Store trail points

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 0; // Start with no points
    }

    void Update()
    {
        Move();
        RecordTrail(); // Record the trail points
    }

    // Method to move the player
    void Move()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

    // Method to record the trail
    void RecordTrail()
    {
        if (trailPoints.Count == 0 || Vector3.Distance(transform.position, trailPoints[trailPoints.Count - 1]) > 0.1f)
        {
            trailPoints.Add(transform.position);
            UpdateLineRenderer();
        }
    }

    // Update the LineRenderer with the trail points
    void UpdateLineRenderer()
    {
        lineRenderer.positionCount = trailPoints.Count;
        lineRenderer.SetPositions(trailPoints.ToArray());
    }

    // Method to handle swipes
    public void OnSwipe(Vector2 swipeDirection)
    {
        // Normalize the swipe direction to allow for omnidirectional movement in the X-Z plane
        if (swipeDirection.magnitude > swipeThreshold)
        {
            // Convert the 2D swipe direction to 3D by mapping the y-axis to z-axis
            moveDirection = new Vector3(swipeDirection.x, 0, swipeDirection.y).normalized; // Set moveDirection to the normalized swipe direction
        }
    }

    // Method to clear the trail (resetting the game, for example)
    public void ClearTrail()
    {
        trailPoints.Clear();
        lineRenderer.positionCount = 0;
    }
}
