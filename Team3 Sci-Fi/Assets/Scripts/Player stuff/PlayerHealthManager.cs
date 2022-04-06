using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public float maxHealth = 100f;
    private bool isTakingDamage;
    public float healthRegenSpeed;

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
