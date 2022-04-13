using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    [SerializeField] private EnterOrExitVehicle enterOrExitScript;
    
    private float horizontalInput;
    private float verticalInput;
    private bool isBrakeing;
    private float currentBrakeForce;
    private float currentSteerAngle;
    
    //Den här siffran kommer vi ge ett värde längre ner
    public float currentMotorTorque;
    
    [SerializeField] private WheelCollider frontLeftCollider;
    [SerializeField] private WheelCollider frontRightCollider;
    [SerializeField] private WheelCollider backLeftCollider;
    [SerializeField] private WheelCollider backRightCollider;
    
    [SerializeField] private Transform frontLeftTransform;
    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform backLeftTransform;
    [SerializeField] private Transform backRightTransform;

    public float speed;
    [SerializeField] private float brakeForce;
    [SerializeField] private float maxSteeringAngle;

    private void FixedUpdate()
    {
        if (enterOrExitScript.inCar)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            isBrakeing = Input.GetKey(KeyCode.LeftControl);
        }
        
        frontLeftCollider.motorTorque = verticalInput * speed;
        frontRightCollider.motorTorque = verticalInput * speed;
        
        
        //currentMotorTorque den här siffran kan vi använda som en parameter för motorljud osv
        currentMotorTorque = (frontRightCollider.motorTorque + frontLeftCollider.motorTorque) / 2f;
        FMODUnity.RuntimeManager.StudioSystem.setParameterByName("RPM", currentMotorTorque);

        
        if (!enterOrExitScript.inCar)
        {
            currentBrakeForce = brakeForce;
        }
        else
        {
            currentBrakeForce = isBrakeing ? brakeForce : 0f;
        }
        
        frontRightCollider.brakeTorque = currentBrakeForce;
        frontLeftCollider.brakeTorque = currentBrakeForce;
        backRightCollider.brakeTorque = currentBrakeForce;
        backLeftCollider.brakeTorque = currentBrakeForce;
        

        currentSteerAngle = maxSteeringAngle * horizontalInput;
        frontLeftCollider.steerAngle = currentSteerAngle;
        frontRightCollider.steerAngle = currentSteerAngle;
        
        UpdateSingleWheel(frontLeftCollider, frontLeftTransform);
        UpdateSingleWheel(frontRightCollider, frontRightTransform);
        UpdateSingleWheel(backRightCollider, backRightTransform);
        UpdateSingleWheel(backLeftCollider, backLeftTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;
        wheelCollider.GetWorldPose(out position, out rotation);
        wheelTransform.rotation = rotation;
        wheelTransform.position = position;
    }
}
