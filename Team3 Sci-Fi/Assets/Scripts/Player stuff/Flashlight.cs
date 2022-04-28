using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public Light flashlight;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && flashlight.enabled == false)
        {
            flashlight.enabled = true;
        }
        else if (Input.GetKeyDown(KeyCode.E) && flashlight.enabled == true)
        {
            
        }
    }   
}
