using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;
    public Light carLightUp;
    public Light carLightDown;
    public EnterOrExitVehicle InCar;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && flashlight.enabled == false && InCar.inCar == false)
        {
            flashlight.enabled = true;
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
    }   
}
