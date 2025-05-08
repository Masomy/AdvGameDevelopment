using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
public int resolution = 30;
    public float timeStep = 0.1f;
    public float maxTime = 3f;
    public LineRenderer lineRenderer;

    void Awake()
    {
        if (!lineRenderer)
            lineRenderer = GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 startPosition, Vector3 initialVelocity)
    {
        List<Vector3> points = new List<Vector3>();
        for (float t = 0; t < maxTime; t += timeStep)
        {
            Vector3 point = startPosition + initialVelocity * t + 0.5f * Physics.gravity * t * t;
            points.Add(point);

            if (points.Count > resolution)
                break;
        }

        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPositions(points.ToArray());
        lineRenderer.enabled = true;
    }

    public void HideTrajectory()
    {
        lineRenderer.enabled = false;
    }
}