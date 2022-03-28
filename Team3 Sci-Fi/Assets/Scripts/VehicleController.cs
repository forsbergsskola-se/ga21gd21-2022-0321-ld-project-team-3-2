using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private bool isBrakeing;
    private float currentBrakeForce;
    private float currentSteerAngle;
    
    [SerializeField] private WheelCollider frontLeftCollider;
    [SerializeField] private WheelCollider frontRightCollider;
    [SerializeField] private WheelCollider backLeftCollider;
    [SerializeField] private WheelCollider backRightCollider;

    [SerializeField] private float speed;
    [SerializeField] private float brakeForce;
    [SerializeField] private float maxSteeringAngle;

    private void FixedUpdate()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        isBrakeing = Input.GetKey(KeyCode.LeftControl);

        frontLeftCollider.motorTorque = verticalInput * speed;
        frontRightCollider.motorTorque = verticalInput * speed;

        currentBrakeForce = isBrakeing ? brakeForce : 0f;
        
        frontRightCollider.brakeTorque = currentBrakeForce;
        frontLeftCollider.brakeTorque = currentBrakeForce;
        backRightCollider.brakeTorque = currentBrakeForce;
        backLeftCollider.brakeTorque = currentBrakeForce;
        

        currentSteerAngle = maxSteeringAngle * horizontalInput;
        frontLeftCollider.steerAngle = currentSteerAngle;
        frontRightCollider.steerAngle = currentSteerAngle;
    }
}
