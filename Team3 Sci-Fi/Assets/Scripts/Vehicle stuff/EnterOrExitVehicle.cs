using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterOrExitVehicle : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject vehicleCamera;
    [SerializeField] private float carEnterRange = 10f;
    [SerializeField] private Vector3 exitCarPosition;
    
    private Transform playerTransform;
    public LayerMask PlayerLayer;
    public bool inCar;
    private bool isInCarRange;
    void Start()
    {
        playerTransform = player.GetComponent<Transform>();
    }

    private void Update()
    {
        isInCarRange = Physics.CheckSphere(transform.position, carEnterRange, PlayerLayer);

        if (inCar && Input.GetKeyDown(KeyCode.E))
        {
            ExitCar();  
        }
        else if (isInCarRange && !inCar && Input.GetKeyDown(KeyCode.E))
        {
            EnterCar();
        }

        if (inCar)
        {
            playerTransform.position = transform.position + exitCarPosition;
        }
        
    }

    private void EnterCar()
    {
        
        inCar = true;
        player.SetActive(false);
        vehicleCamera.SetActive(true);
        
        
        // Här kan man köra vehicle start ljud
        
        
    }

    private void ExitCar()
    {
        inCar = false;
        vehicleCamera.SetActive(false);
        player.SetActive(true);
        
        
        // Här kan man köra vad man vill göra när man går ut ur bilen
        
        
    }
}
