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
    
    private FMOD.Studio.PARAMETER_ID yxParam;
    
    private FMOD.Studio.EventInstance yInst;
    
    private FMOD.Studio.PLAYBACK_STATE state;


    // Start is called before the first frame update
    void Start()
    {
        FMOD.Studio.EventDescription yxParamEventDesc;
        
        yInst.getDescription(out yxParamEventDesc);
        
        FMOD.Studio.PARAMETER_DESCRIPTION yxParamDescription;
        
        yxParamEventDesc.getParameterDescriptionByName("YX", out yxParamDescription);
        
        yxParam = yxParamDescription.id;

        enterExitVehicleScript = vehiclePos.GetComponent<EnterOrExitVehicle>();
    }


   

    private void FixedUpdate()
    {
        
    }

    void Update()
    {
        
       
        playerElevation = playerPos.position.y;
        elevationParameter = playerElevation - mapLowestPoint;
        
        // FMODUnity.RuntimeManager.StudioSystem.setParameterByID(yxParam,elevationParameter);
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("YX", 15);
        


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
