using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DroneController : MonoBehaviour
{ 
    [SerializeField] private float moveSpeed = 2f;
    

    [SerializeField]private Transform[] wayPoint;

    private Transform currentTarget;

    private int currentIndex = 0;

    private void Start()
    {
        
        currentTarget = wayPoint[currentIndex];
    }

    void Update()
    {
        if (currentIndex >= wayPoint.Length)
        {
            return;
        }
        Vector2 currentTargetPosition = currentTarget.position - transform.position;
        if (currentTargetPosition.sqrMagnitude <= 0)
        {
            currentIndex++;
            
            if (currentIndex >= wayPoint.Length)
                return;
            
            currentTarget = wayPoint[currentIndex];
        }
        MoveToTarget(currentTarget);
    }

    private void MoveToTarget(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
    
}