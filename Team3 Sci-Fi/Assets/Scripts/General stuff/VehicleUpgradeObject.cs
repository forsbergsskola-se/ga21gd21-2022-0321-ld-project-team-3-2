using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleUpgradeObject : MonoBehaviour
{
   public bool reinforcedTireUpgrade;
   public bool reincorfecHullUpgrade;
   public bool speedUpgrade;
   public float speedUpgradeValue;
   private bool isInObjectRange;
   public float pickUpRange;
   public LayerMask playerLayer;
   public Animator upgradePopup;
   
   private GameProgressionManager gameProgress;

   private void Start()
   {
      gameProgress = FindObjectOfType<GameProgressionManager>();
   }

   private void Update()
   {
      if (!Input.GetKeyDown(KeyCode.F))
      {
         return;
      }
      
      isInObjectRange = Physics.CheckSphere(transform.position, pickUpRange, playerLayer);

      if (!isInObjectRange)
      {
         return;
      }
      
      if (reincorfecHullUpgrade)
      {
         gameProgress.hasSandstormUpgrade = true;
         gameProgress.vehicleUpgradeLevel++;
         FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Car Lvl", gameProgress.vehicleUpgradeLevel);
      }
      else if (reinforcedTireUpgrade )
      {
         gameProgress.hasScorchedEarthUpgrade = true;
         upgradePopup.SetTrigger("Upgrade");
         gameProgress.vehicleUpgradeLevel++;
         FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Car Lvl", gameProgress.vehicleUpgradeLevel);
      }
      else
      {
         gameProgress.GetSpeedUpgrade(speedUpgradeValue);
      }
      
      Destroy(gameObject);
   }
}
