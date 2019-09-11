using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchArcRenderer : MonoBehaviour
{
    public LineRenderer lr;

    public float velocity = 5.0f;
    public float angle = 45.0f;
    public int resolution = 10;

    private float g;
    private float radianAngle;

    private void Awake()
    {
        g = Mathf.Abs(Physics.gravity.y);
        RenderArc();
    }

    //private void OnValidate()
    //{
    //    if (lr != null && Application.isPlaying)
    //        RenderArc();
    //}

    private void Update()
    {
        angle = Vector3.Angle(Vector3.forward, transform.forward);
        Debug.Log(angle);
        RenderArc();
    }

    private void RenderArc()
    {
        lr.positionCount = (resolution + 1);
        lr.SetPositions(CalculateArcArray());
    }

    private Vector3[] CalculateArcArray()
    {
        Vector3[] arcArray = new Vector3[resolution + 1];

        radianAngle = Mathf.Deg2Rad * angle;
        float maxDistance = (velocity * velocity * Mathf.Sin(2 * radianAngle)) / g;

        for (int i = 0; i <= resolution; i++)
        {
            float t = (float)i / (float)resolution;
            arcArray[i] = CalculateArcPoint(t, maxDistance);
        }
        return arcArray;
    }

    private Vector3 CalculateArcPoint(float t, float maxDistance)
    {
        float x = t * maxDistance;
        float y = transform.position.y + x * Mathf.Tan(radianAngle) -
            ((g * x * x) / (2 * velocity * velocity * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
        return new Vector3(x, y);
    }
}
