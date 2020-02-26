using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionsController : MonoBehaviour
{
    public Queue<Vector3> points;
    Camera cam;
    void Start()
    {
        cam = Camera.main;
    }

    public void AddPosition()
    {
        points.Enqueue(Input.mousePosition);
        Debug.Log(Input.mousePosition);
    }

    public Vector3 GetNextPosition()
    {
        if (points.Count > 0)
            return points.Dequeue();
        return transform.position;
    }

    public void ClearAllPoints()
    {
        points = new Queue<Vector3>();
    }

}
