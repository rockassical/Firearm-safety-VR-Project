using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeRenderer : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Transform> segmentPositions = new List<Transform>();
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        // Populate segment positions
        foreach (Transform child in transform)
        {
            if (child.CompareTag("RopeSegment"))
                segmentPositions.Add(child);
        }
        // Set the LineRenderer vertex count
        lineRenderer.positionCount = segmentPositions.Count;
    }
    private void Update()
    {
        for (int i = 0; i < segmentPositions.Count; i++)
        {
            lineRenderer.SetPosition(i, segmentPositions[i].position);
        }
    }
}