using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SettingsController : MonoBehaviour
{

    [SerializeField] private Animator SettingsAnim;
    private PlayerHealthManager healthManager;
    private bool inMenu;
    private MouseLook fpsView;

    private void Start()
    {
        healthManager = FindObjectOfType<PlayerHealthManager>();
        fpsView = FindObjectOfType<MouseLook>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            OpenMenu();
        }

        // close menu by running resume button
    }

    private void OpenMenu()
    {
        // pause game
        // do sound snapshot
        
        // bring up options
        inMenu = true;
        fpsView.enabled = false;
        Cursor.lockState = CursorLockMode.None;
        SettingsAnim.SetTrigger("OpenMenu");

    }
    

    public void ResumeButton()
    {
        // unpause game
        // do sound snapshot
        // close options
    }

    public void MainMenuButton()
    {
        //send player to MainMenu
    }

    public void OptionsMenuButton()
    {
        //Close options and open new object
        //Dont unpause or boot out of menu
    }

    public void RespawnButton()
    {
        //close by running resumebutton
        healthManager.Death();
    }
    
}
