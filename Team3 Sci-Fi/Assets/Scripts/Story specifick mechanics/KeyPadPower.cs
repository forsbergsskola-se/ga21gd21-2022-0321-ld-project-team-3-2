using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyPadPower : MonoBehaviour
{
    [SerializeField] private GameObject keyPadHolder;
    [SerializeField] private VehicleUpgradeObject vehicleUpgrade;
    [SerializeField] private BasicDialogueTrigger lockedDialogue;
    [SerializeField] private Image inputBox;
    [SerializeField] private TextMeshProUGUI NumberInput;
    [SerializeField] private int passwordLength;
    [SerializeField] private string correctPassword;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private float interactionRange;
    private bool inKeyPad;
    private MouseLook fpsView;

    private void Start()
    {
        fpsView = FindObjectOfType<MouseLook>();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.F))
        {
            return;
        }

        if (Physics.CheckSphere(transform.position, interactionRange, playerLayer) && inKeyPad)
        {
            keyPadHolder.SetActive(false);
            inKeyPad = false;
            Cursor.lockState = CursorLockMode.Locked;
            fpsView.enabled = true;
        }
        else if (Physics.CheckSphere(transform.position, interactionRange, playerLayer) && !inKeyPad)
        {
            keyPadHolder.SetActive(true);
            inKeyPad = true;
            Cursor.lockState = CursorLockMode.None;
            fpsView.enabled = false;
        }
        

    }


    public void OkButton()
    {
        if (NumberInput.text == correctPassword)
        {
            lockedDialogue.enabled = false;
            vehicleUpgrade.enabled = true;
            inputBox.color = Color.green;
        }
    }
    public void BackSpaceButton()
    {
        NumberInput.text = "";
    }
    public void Button1()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "1";
    }
    public void Button2()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "2";
    }
    public void Button3()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "3";
    }
    public void Button4()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "4";
    }
    public void Button5()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "5";
    }
    public void Button6()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "6";
    }
    public void Button7()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "7";
    }
    public void Button8()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "8";
    }
    public void Button9()
    {
        if (NumberInput.text.Length >= passwordLength) return;
        NumberInput.text += "9";
    }
    
}
