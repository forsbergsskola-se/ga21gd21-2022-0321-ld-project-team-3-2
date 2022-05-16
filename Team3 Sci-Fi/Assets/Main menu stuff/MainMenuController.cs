using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{


    public float textScrollTime;
    public FMODUnity.EventReference clickSoundPlaceEventHere;
    private FMOD.Studio.EventInstance clickSoundInstance;
    public int sceneIndexToLoad;
    public Animator textAnim;
    
    private void Start()
    {
        clickSoundInstance = FMODUnity.RuntimeManager.CreateInstance(clickSoundPlaceEventHere);
    }
    
    
    
    public void StartGame()
    {
        clickSoundInstance.start();
        StartCoroutine(StartMenuText());
    }

    IEnumerator StartMenuText()
    {
        enabled = false;
        textAnim.SetTrigger("start");
        yield return new WaitForSeconds(textScrollTime);
        SceneManager.LoadSceneAsync(sceneIndexToLoad);
    }
    
    public void ExitGame()
    {   
        clickSoundInstance.start();
        Application.Quit();
    }
}
