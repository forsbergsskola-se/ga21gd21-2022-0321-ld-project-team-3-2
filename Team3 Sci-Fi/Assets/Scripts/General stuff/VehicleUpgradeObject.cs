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
   private InteractionManager interact;
   
   private GameProgressionManager gameProgress;
   public QuestWaypoint questWaypoint;
   public GameObject dialogue1TriggerOnComplete;
   public GameObject dialogue2TriggerOnComplete;

   private void Start()
   {
      interact = FindObjectOfType<InteractionManager>();
      gameProgress = FindObjectOfType<GameProgressionManager>();
   }

   private void Update()
   {
      isInObjectRange = Physics.CheckSphere(transform.position, pickUpRange, playerLayer);

      if (isInObjectRange)
      {
         interact.ShowInteractMessage("Press E to interact");
      }
      else
      {
         interact.HideInteractMessage();
      }
      
      if (!Input.GetKeyDown(KeyCode.E))
      {
         return;
      }
      
      if (!isInObjectRange)
      {
         return;
      }
      
      if (reincorfecHullUpgrade)
      {
         gameProgress.hasSandstormUpgrade = true;
         gameProgress.vehicleUpgradeLevel++;
         questWaypoint.targetArrayValue++;
         questWaypoint.activeQuestArrayValue++;
         dialogue2TriggerOnComplete.SetActive(true);
         FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Car Lvl", gameProgress.vehicleUpgradeLevel);
      }
      else if (reinforcedTireUpgrade)
      {
         gameProgress.hasScorchedEarthUpgrade = true;
         gameProgress.currentCheckpoint = 1;
         gameProgress.vehicleUpgradeLevel++;
         questWaypoint.targetArrayValue++;
         questWaypoint.activeQuestArrayValue++;
         dialogue1TriggerOnComplete.SetActive(true);
         FMODUnity.RuntimeManager.StudioSystem.setParameterByName("Car Lvl", gameProgress.vehicleUpgradeLevel);
      }
      else
      {
         gameProgress.GetSpeedUpgrade(speedUpgradeValue);
      }
      
      interact.HideInteractMessage();
      Destroy(gameObject);
   }
}
