using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;
    public Light carLightUp;
    public Light carLightDown;
    
    [SerializeField] private EnterOrExitVehicle InCar;
    private Random flickerTimeRandom = new Random();
    [SerializeField] private double flickerTimeVal;
    [SerializeField] private float flickerTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && flashlight.enabled == false && InCar.inCar == false)
        {
            StartCoroutine(Flicker());
        }
        else if (Input.GetKeyDown(KeyCode.F) && flashlight.enabled && InCar.inCar == false)
        {
            flashlight.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.F) && carLightUp.enabled == false && InCar.inCar)
        {
            carLightUp.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && carLightUp.enabled && InCar.inCar)
        {
            carLightUp.enabled = false;
        }
        
        if (Input.GetKeyDown(KeyCode.F) && carLightDown.enabled == false && InCar.inCar)
        {
            carLightDown.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.F) && carLightDown.enabled && InCar.inCar)
        {
            carLightDown.enabled = false;
        }

        IEnumerator Flicker()
        {
            flashlight.enabled = true;
            flickerTimeVal = flickerTimeRandom.NextDouble() / 10;
            flickerTime = Convert.ToSingle(flickerTimeVal);
            yield return new WaitForSeconds(flickerTime);
            flashlight.enabled = false;
            flickerTimeVal = flickerTimeRandom.NextDouble() / 10;
            flickerTime = Convert.ToSingle(flickerTimeVal);
            yield return new WaitForSeconds(flickerTime);
            flashlight.enabled = true;
        }
    }   
}
