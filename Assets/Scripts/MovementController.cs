using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    SpeedController speedController;

    PositionsController positions;

    public Vector3 targetPos;
    
    void Start()
    {
        speedController = GetComponent<SpeedController>();
        positions = GetComponent<PositionsController>();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speedController.Speed);
        if (Vector3.Distance(targetPos,transform.position)<0.5f)
            CheckForNewPos();
    }
    void CheckForNewPos()
    {
        targetPos = positions.GetNextPosition();
    }
    public void Stop()
    {
        targetPos = transform.position;
    }
}
