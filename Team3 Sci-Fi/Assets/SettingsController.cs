using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SettingsController : MonoBehaviour
{

    [SerializeField] private Animator SettingsAnim;
    private PlayerHealthManager healthManager;
    [HideInInspector] public bool inMenu;
    private MouseLook fpsView;
    private Movement playerMove;

    private void Start()
    {
        playerMove = FindObjectOfType<Movement>();
        healthManager = FindObjectOfType<PlayerHealthManager>();
        fpsView = FindObjectOfType<MouseLook>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !inMenu)
        {
            OpenMenu();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && inMenu)
        {
            ResumeButton();
        }
    }

    private void OpenMenu()
    {
        //pause the game
        Time.timeScale = 0;
        
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
        Time.timeScale = 1;
        
        // do sound snapshot
        
        //close options
        inMenu = false;
        fpsView.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        SettingsAnim.SetTrigger("CloseMenu");
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
        ResumeButton();
        healthManager.Death();
        StopAllCoroutines();
        StartCoroutine(DelayedDeath());
    }

    private IEnumerator DelayedDeath()
    {
        playerMove.enabled = false;
        yield return new WaitForSeconds(0.5f);
        healthManager.Death();
        playerMove.enabled = true;
    }

}
