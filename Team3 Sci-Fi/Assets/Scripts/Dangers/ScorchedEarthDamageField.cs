using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using Unity.Mathematics;
using UnityEngine;

public class ScorchedEarthDamageField : MonoBehaviour
{
    public float damagePerFrame;
    public LayerMask playerLayer;
    public LayerMask vehicleLayer;
    private PlayerHealthManager playerHealth;
    private Collider damageField;
    private bool isPlayerIn;
    private bool isVehicleIn;
   

    private GameProgressionManager gameProgress;

    private void Start()
    {
        gameProgress = FindObjectOfType<GameProgressionManager>();
        playerHealth = FindObjectOfType<PlayerHealthManager>();
        damageField = GetComponent<Collider>();
        
    }

    private void FixedUpdate()
    {
        isPlayerIn = Physics.CheckBox(damageField.bounds.center,damageField.bounds.extents,quaternion.Euler(0),playerLayer);
        isVehicleIn = Physics.CheckBox(damageField.bounds.center,damageField.bounds.extents,quaternion.Euler(0),vehicleLayer);
        
        if (isPlayerIn)
        {
            playerHealth.TakeDamage(damagePerFrame);
        }
        else if (isVehicleIn)
        {
            if (!gameProgress.hasScorchedEarthUpgrade)
            {
                playerHealth.TakeDamage(damagePerFrame);
            }
        }
    }
}
