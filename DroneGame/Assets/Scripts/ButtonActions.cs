using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActions : MonoBehaviour
{
    [SerializeField] private GameObject Controller;

    [SerializeField] private GameObject sceneMap;

    [SerializeField] private GameObject Drone;

    [SerializeField] private DroneController energyDrone;

    public void ButtonDecolarOnClick()
    {
        if (Controller.activeInHierarchy == true)
        {
            
           
            
            Controller.SetActive(false);
        }
        else
        {
            Controller.SetActive(true);
        }
        
        
        if (sceneMap.activeInHierarchy == false)
        {
            sceneMap.SetActive(true);
        }
        else
        {
            sceneMap.SetActive(sceneMap);
        }


        if (Drone.activeInHierarchy == false)
        {
            Drone.SetActive(true);
        }
        else
        {
            Drone.SetActive(false);
        }
    }

    public void AddEnergyOnClick()
    {
        energyDrone.energy += 42.8f;
        Debug.Log("+1% energy");
    }

    public void EnergyOnClick()
    {
        energyDrone.energy += 428f;
        Debug.Log("+10% energy");
    }

    public void Remove10Energy()
    {
        energyDrone.energy -= 428f;
        Debug.Log("-10% energy");
    }

    public void Remove1Energy()
    {
        energyDrone.energy -= 42.8f;
        Debug.Log("-1% energy");
    }

}