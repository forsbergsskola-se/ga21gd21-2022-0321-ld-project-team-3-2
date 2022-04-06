using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    public float maxHealth;
    private bool isTakingDamage;

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

    private void Update()
    {
        if (currentHealth >= 0) 
        {
            Death();
        }
        RegenerateHealth();
    }

    private void LateUpdate()
    {
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
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        isDead = false;
    }

    private void RegenerateHealth()
    {
        if (!isDead && !isTakingDamage)
        {
            currentHealth += maxHealth / 10f * Time.deltaTime;
        }
    }
}
