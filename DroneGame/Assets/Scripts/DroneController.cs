using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DroneController : MonoBehaviour
{
    [SerializeField] private GameObject gameOver;

    [SerializeField] private GameObject Drone;

    [SerializeField] private GameObject sceneMap;
    
    [SerializeField] public float energy;
    
    [SerializeField] private float moveSpeed = 4f;
    
    [SerializeField]private Transform[] wayPoint;

    private Transform currentTarget;

    private int currentIndex = 0;

    private void Start()
    {
        currentTarget = wayPoint[currentIndex];
    }

    void Update()
    {
        if (energy > 0)
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
                {
                    onReachEndPoint();
                    
                    return;
                }
            
                currentTarget = wayPoint[currentIndex];
                Vector2 distance = currentTarget.position - transform.position;
                Debug.Log(distance.magnitude);
            }
            MoveToTarget(currentTarget);

            energy--;
            float energyGasto = Time.time;
        }
        else
        {
            OnOutOffEnergy();
        }
    }

    private void onReachEndPoint()
    {
        if (energy == 0)
        {
            Debug.Log("Perimetro Completo");
        }
        if (energy > 0)
        {
            Debug.Log("Ainda resta energia");
        }
    }

    private void OnOutOffEnergy()
    {
        Drone.SetActive(false);
            
        sceneMap.SetActive(false);
            
        gameOver.SetActive(true);
        Debug.Log("Sem Bateria");
        
    }

    private void MoveToTarget(Transform target)
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
    }
    
}
