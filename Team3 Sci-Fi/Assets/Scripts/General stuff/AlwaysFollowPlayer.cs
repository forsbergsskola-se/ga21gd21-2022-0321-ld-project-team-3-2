using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysFollowPlayer : MonoBehaviour
{
    [SerializeField] private Transform playerPos;
    [SerializeField] private Transform vehiclePos;
    private Vector3 playerPosY;
    private EnterOrExitVehicle enterExitVehicleScript;

    private void Start()
    {
        enterExitVehicleScript = vehiclePos.GetComponent<EnterOrExitVehicle>();
    }

    void Update()
    {
        playerPosY = new Vector3(0f, playerPos.position.y,0f);
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
