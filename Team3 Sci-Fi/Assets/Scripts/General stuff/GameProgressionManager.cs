using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgressionManager : MonoBehaviour
{
    [SerializeField] private VehicleController vehicleControll;
    
    public bool hasScorchedEarthUpgrade;
    public bool hasSandstormUpgrade;
    private int speedUpgradeAmount = 0;

    public void GetSpeedUpgrade(float speedUpgradeValue)
    {
        vehicleControll.speed += speedUpgradeValue;
        speedUpgradeAmount += 1;
    }
}
