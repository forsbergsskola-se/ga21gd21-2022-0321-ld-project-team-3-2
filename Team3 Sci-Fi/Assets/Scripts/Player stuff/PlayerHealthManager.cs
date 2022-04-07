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

    
    
    private void Start()
    {
        currentHealth = maxHealth;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
