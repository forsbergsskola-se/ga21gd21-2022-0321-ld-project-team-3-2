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
    public float elevationParameter;

    private void Start()
    {
        enterExitVehicleScript = vehiclePos.GetComponent<EnterOrExitVehicle>();
    }

    void Update()
    {
        
       
        playerElevation = playerPos.position.y;
        elevationParameter = playerElevation - mapLowestPoint;
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Elevation test",elevationParameter);


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
