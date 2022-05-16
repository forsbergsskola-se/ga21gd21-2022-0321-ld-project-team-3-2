using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealthManager : MonoBehaviour
{

    [Header("This script should not be attached to the player prefab")] [Header("")] 
    
    [SerializeField] private Animator anim;
    public float maxHealth = 100f;
    private bool isTakingDamage;
    public float healthRegenSpeed;
    private GameProgressionManager gameProgress;
    [SerializeField] private Transform player;
    [SerializeField] private Transform vehicleFront;
    [SerializeField] private Transform vehicleBack;
    private EnterOrExitVehicle vehicleEnter;
    [SerializeField] private Image vignette;
    [SerializeField] private Image veins;
    private FMOD.Studio.EventInstance regenSound;
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
        
        var vignetteColor = vignette.color;
        var veinsColor = veins.color;
        vignetteColor.a = Mathf.Abs(currentHealth * 0.01f-1);
        veinsColor.a = Mathf.Abs(currentHealth * 0.01f-1);
        
        vignette.color = vignetteColor;
        veins.color = veinsColor;

        if (!isTakingDamage && currentHealth < maxHealth)
        {
            regenSound.start();
        }
        else
        {
            regenSound.stop(STOP_MODE.IMMEDIATE);
        }


    }

    private void Start()
    {
        vehicleEnter = FindObjectOfType<EnterOrExitVehicle>();
        currentHealth = maxHealth;
        gameProgress = FindObjectOfType<GameProgressionManager>();
        regenSound = FMODUnity.RuntimeManager.CreateInstance("event:/Player/Health regeneration");
    }

    private void FixedUpdate()
    {
        if (currentHealth <= 0) 
        {
            Death();
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
        if (isDead == false)
        {
            isDead = true;
            StartCoroutine(DeathAnim());
        }
    }

    IEnumerator DeathAnim()
    {
        anim.SetTrigger("Die");
        FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Player death");
        yield return new WaitForSeconds(2f);
        if (vehicleEnter.inCar)
        {
            vehicleEnter.ExitCarOnDeath();
        }
        vehicleFront.position = new Vector3(0, 3, 7.77f) + gameProgress.CheckPoints[gameProgress.currentCheckpoint].position;
        vehicleBack.position = new Vector3(0, 3, -2.5f) + gameProgress.CheckPoints[gameProgress.currentCheckpoint].position;
        player.position = gameProgress.CheckPoints[gameProgress.currentCheckpoint].position + new Vector3(3,0,0);
        currentHealth = maxHealth;
        isDead = false;
    }

    private void RegenerateHealth()
    {
        if (!isDead && !isTakingDamage && currentHealth < 100f)
        {
            currentHealth += maxHealth * (healthRegenSpeed / 1000f);
        }
    }
}
