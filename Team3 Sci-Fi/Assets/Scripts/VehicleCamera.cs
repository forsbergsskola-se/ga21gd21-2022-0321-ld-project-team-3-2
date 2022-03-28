using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleCamera : MonoBehaviour
{

    [SerializeField] private Vector3 offset;
    [SerializeField] private Transform objectToFollow;
    [SerializeField] private float followSpeed;
    [SerializeField] private float rotationSpeed;
    
 
    void Update()
    {
        Vector3 targetPosition = objectToFollow.TransformPoint(offset);
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        var direction = objectToFollow.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
    }
}
