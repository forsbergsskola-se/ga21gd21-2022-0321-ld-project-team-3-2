using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SettingsController : MonoBehaviour
{

    [SerializeField] private Animator SettingsAnim;
    [SerializeField] private Animator OptionsMenuAnim;
    private PlayerHealthManager healthManager;
    [HideInInspector] public bool inMenu;
    private MouseLook fpsView;
    private Movement playerMove;
    private bool inSettings;

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
        else if (Input.GetKeyDown(KeyCode.Escape) && inMenu && !inSettings)
        {
            Time.timeScale = 1;
            inMenu = false;
            fpsView.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            SettingsAnim.SetTrigger("CloseMenu");
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && inMenu && inSettings)
        {
            inSettings = false;
            OptionsMenuAnim.SetTrigger("CloseSettings");
            SettingsAnim.SetTrigger("OpenState");
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
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
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
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
    }

    public void OptionsMenuButton()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
        //Close options and open new object
        SettingsAnim.SetTrigger("SettingsTime");
        OptionsMenuAnim.SetTrigger("OpenSettings");
        inSettings = true;
        //Dont unpause or boot out of menu
    }

    public void Resolution1920x1080()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
    }
    public void Resolution1600x900()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
    }
    public void Resolution2560x1440()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
    }
    public void Fullscreen()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
    }
    public void Windowed()
    {
        FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Clicks");
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
