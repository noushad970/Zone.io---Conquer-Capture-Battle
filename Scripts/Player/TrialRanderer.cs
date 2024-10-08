using UnityEngine;
using System.Collections.Generic;

public class TrailRanderer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    private List<Vector3> trailPositions = new List<Vector3>();

    void Start()
    {
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        UpdateTrail();
    }

    void UpdateTrail()
    {
        // Add the current position of the player to the trail
        if (trailPositions.Count == 0 || Vector3.Distance(trailPositions[trailPositions.Count - 1], transform.position) > 0.1f)
        {
            trailPositions.Add(transform.position);
            lineRenderer.positionCount = trailPositions.Count;
            lineRenderer.SetPositions(trailPositions.ToArray());
        }
    }
}
