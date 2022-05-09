using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{
    
    [Header("This script should not be attached to the player prefab")]
    [Header("")]
    
    public float maxHealth = 100f;
    private bool isTakingDamage;
    public float healthRegenSpeed;
    [SerializeField] private Image healthIndicator;
    private GameProgressionManager gameProgress;
    [SerializeField] private Transform player;
    [SerializeField] private Transform vehicleFront;
    [SerializeField] private Transform vehicleBack;
    private EnterOrExitVehicle vehicleEnter;
    public bool isDead
    {
        get;
        private set;
    } 
    public float currentHealth
    {
        get;
        private set;
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            Death();
        }
    }

    private void Start()
    {
        vehicleEnter = FindObjectOfType<EnterOrExitVehicle>();
        currentHealth = maxHealth;
        gameProgress = FindObjectOfType<GameProgressionManager>();
    }

    private void FixedUpdate()
    {
        if (currentHealth <= 0) 
        {
            Death();
        }

        if (currentHealth > maxHealth * 0.67f)
        {
            healthIndicator.color = Color.cyan;
        }
        else if (currentHealth > maxHealth * 0.34f && currentHealth < maxHealth * 0.67f)
        {
            healthIndicator.color = Color.yellow;
        }
        else
        {
            healthIndicator.color = Color.red;
        }
        RegenerateHealth();
        isTakingDamage = false;
    }

    

    public void TakeDamage(float damage)
    {
        isTakingDamage = true;
        currentHealth -= damage;
    }

    public void Death()
    {
        isDead = true;
        if (vehicleEnter.inCar)
        {
            vehicleEnter.ExitCarOnDeath();
        }
        vehicleFront.position = new Vector3(0, 3, 7.77f) + gameProgress.CheckPoints[gameProgress.currentCheckpoint].position;
        vehicleBack.position = new Vector3(0, 3, -2.5f) + gameProgress.CheckPoints[gameProgress.currentCheckpoint].position;
        player.position = gameProgress.CheckPoints[gameProgress.currentCheckpoint].position + new Vector3(3,0,0);
        isDead = false;
        currentHealth = maxHealth;
    }

    private void RegenerateHealth()
    {
        if (!isDead && !isTakingDamage && currentHealth < 100f)
        {
            currentHealth += maxHealth * (healthRegenSpeed / 1000f);
        }
    }
}
