using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

public class EnterOrExitVehicle : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject vehicleCamera;
    [SerializeField] private float carEnterRange = 10f;
    [SerializeField] private Vector3 exitCarPosition;

    private SettingsController settings;
    private FMOD.Studio.EventInstance motorSound;
    private Transform playerTransform;
    public LayerMask PlayerLayer;
    public bool inCar;
    private bool isInCarRange;
    private InteractionManager interact;
    public string interactMessage;
    private bool enterCarCD = false;
    void Start()
    {
        settings = FindObjectOfType<SettingsController>();
        interact = FindObjectOfType<InteractionManager>();
        playerTransform = player.GetComponent<Transform>();
        motorSound = FMODUnity.RuntimeManager.CreateInstance("event:/Vehicle/Motor");
    }

    private void Update()
    {
        isInCarRange = Physics.CheckSphere(transform.position, carEnterRange, PlayerLayer);

        if (inCar && Input.GetKeyDown(KeyCode.Mouse0) && enterCarCD && !settings.inMenu)
        {
            ExitCar();
            StartCoroutine(Pause());
        }
    }
    
    private void OnMouseOver()
    {
        if (isInCarRange && !inCar)
        {
            interact.ShowInteractMessage(interactMessage);
        }
    }

    private void OnMouseDown()
    {
        if (isInCarRange && !inCar && !enterCarCD && !settings.inMenu)
        {
            EnterCar();
            StartCoroutine(Pause());
        }
    }

    IEnumerator Pause()
    {
        yield return new WaitForSeconds(0.5f);
        enterCarCD = !enterCarCD;
    }

    private void OnMouseExit()
    {
        interact.HideInteractMessage();
    }

    private void EnterCar()
    {
        
        inCar = true;
        player.SetActive(false);
        vehicleCamera.SetActive(true);
        interact.HideInteractMessage();
        motorSound.start();
        FMODUnity.RuntimeManager.PlayOneShot("event:/Vehicle/Vehicle Enter");
    }

    public void ExitCar()
    {
        inCar = false;
        vehicleCamera.SetActive(false);
        playerTransform.position = transform.position + exitCarPosition;
        player.SetActive(true);
        motorSound.stop(STOP_MODE.IMMEDIATE);
        FMODUnity.RuntimeManager.PlayOneShot("event:/Vehicle/Vehicle Exit");
    }
    public void ExitCarOnDeath()
    {
        inCar = false;
        vehicleCamera.SetActive(false);
        player.SetActive(true);
        motorSound.stop(STOP_MODE.IMMEDIATE);
        enterCarCD = !enterCarCD;
        StopAllCoroutines();
    }
}
