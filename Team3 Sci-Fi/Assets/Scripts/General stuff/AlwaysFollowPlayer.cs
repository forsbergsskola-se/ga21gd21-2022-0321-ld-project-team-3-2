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
    // Start is called before the first frame update
    void Start()
    {

        enterExitVehicleScript = vehiclePos.GetComponent<EnterOrExitVehicle>();
    }

    void Update()
    {
        
       
        playerElevation = playerPos.position.y;
        elevationParameter = playerElevation - mapLowestPoint;
        
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("YX", elevationParameter);
        


        if (enterExitVehicleScript.inCar)
        {
            transform.position = vehiclePos.position + new Vector3(0,395,0);
        }
        else
        {
            transform.position = playerPos.position;
        }
    }
}
