using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Transform vehiclePos;
    [SerializeField] private float mapLowestPoint;
    private float playerElevation;
    private EnterOrExitVehicle enterExitVehicleScript;

    private void Start()
    {
        enterExitVehicleScript = vehiclePos.GetComponent<EnterOrExitVehicle>();
    }

    void Update()
    {
        
        
       
        playerElevation = playerPos.position.y;
        float elevationParameter = playerElevation - mapLowestPoint;
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Elevation Y axen", elevationParameter);


        if (enterExitVehicleScript.inCar)
        {
            transform.position = vehiclePos.position;
        }
        else
        {
            transform.position = playerPos.position;
        }
    }
}
