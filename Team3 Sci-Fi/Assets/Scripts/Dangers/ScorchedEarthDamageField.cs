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
    private FMOD.Studio.EventInstance scorchSound;

    private GameProgressionManager gameProgress;

    private void Start()
    {
        gameProgress = FindObjectOfType<GameProgressionManager>();
        playerHealth = FindObjectOfType<PlayerHealthManager>();
        damageField = GetComponent<Collider>();
        scorchSound = FMODUnity.RuntimeManager.CreateInstance("event:/Ambi/Scorched Earth");
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

    private void OnTriggerEnter(Collider other)
    {
        if (isPlayerIn)
        {
            scorchSound.start();
        }
        else if (isVehicleIn)
        {
            if (!gameProgress.hasScorchedEarthUpgrade)
            {
                scorchSound.start();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!isPlayerIn)
        {
            scorchSound.stop(STOP_MODE.ALLOWFADEOUT);
        }
        else if (!isVehicleIn)
        {
            if (!gameProgress.hasScorchedEarthUpgrade)
            {
                scorchSound.stop(STOP_MODE.ALLOWFADEOUT);
            }
        }
    }
}
