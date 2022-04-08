using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SandstormDamageField : MonoBehaviour
{
    public float damagePerFrame;
    public LayerMask playerLayer;
    public LayerMask vehicleLayer;
    private PlayerHealthManager playerHealth;
    private Collider damageField;

    private GameProgressionManager gameProgress;

    private void Start()
    {
        gameProgress = FindObjectOfType<GameProgressionManager>();
        playerHealth = FindObjectOfType<PlayerHealthManager>();
        damageField = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        if (Physics.CheckBox(damageField.bounds.center,damageField.bounds.extents,quaternion.Euler(0),playerLayer))
        {
            playerHealth.TakeDamage(damagePerFrame);
        }
        else if (Physics.CheckBox(damageField.bounds.center,damageField.bounds.extents,quaternion.Euler(0),vehicleLayer))
        {
            if (!gameProgress.hasSandstormUpgrade)
            {
                playerHealth.TakeDamage(damagePerFrame);
            }
        }
    }
}
