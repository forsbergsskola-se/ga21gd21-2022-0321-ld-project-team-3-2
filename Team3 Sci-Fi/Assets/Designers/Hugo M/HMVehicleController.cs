using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HMVehicleController : MonoBehaviour
{
    [SerializeField] private EnterOrExitVehicle enterOrExitScript;
    
    private float horizontalInput;
    private float verticalInput;
    private bool isBrakeing;
    private float currentBrakeForce;
    private float currentSteerAngle;
    
    [SerializeField] private WheelCollider frontLeftCollider;
    [SerializeField] private WheelCollider frontRightCollider;
    [SerializeField] private WheelCollider backLeftCollider;
    [SerializeField] private WheelCollider backRightCollider;
    
    // [SerializeField] private WheelCollider frontLeftCollider2;
    // [SerializeField] private WheelCollider frontRightCollider2;
    // [SerializeField] private WheelCollider backLeftCollider2;
    // [SerializeField] private WheelCollider backRightCollider2;
    // [SerializeField] private WheelCollider middleBackRightWheel2;
    // [SerializeField] private WheelCollider middleBackLeftWheel2;
    
    [SerializeField] private Transform frontLeftTransform;
    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform backLeftTransform;
    [SerializeField] private Transform backRightTransform;
   
    // [SerializeField] private Transform frontLeftTransform2;
    // [SerializeField] private Transform frontRightTransform2;
    // [SerializeField] private Transform backLeftTransform2;
    // [SerializeField] private Transform backRightTransform2;
    // [SerializeField] private Transform middleBackRightWheelTransform2;
    // [SerializeField] private Transform middleBackLeftWheelTransform2;
        
    [SerializeField] private float speed;
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
        
        backLeftCollider.motorTorque = verticalInput * speed;
        backRightCollider.motorTorque = verticalInput * speed;

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
      
        // UpdateSingleWheel(frontLeftCollider2, frontLeftTransform2);
        // UpdateSingleWheel(frontRightCollider2, frontRightTransform2);
        // UpdateSingleWheel(backRightCollider2, backRightTransform2);
        // UpdateSingleWheel(backLeftCollider2, backLeftTransform2);
        // UpdateSingleWheel(middleBackRightWheel2,middleBackRightWheelTransform2);
        // UpdateSingleWheel(middleBackLeftWheel2,middleBackLeftWheelTransform2);
    }

    private void UpdateSingleWheel(WheelCollider WheelCollider, Transform wheelTransform)
    {
        Vector3 position;
        Quaternion rotation;
        WheelCollider.GetWorldPose(out position, out rotation);
        wheelTransform.rotation = rotation;
        wheelTransform.position = position;
    }
}
