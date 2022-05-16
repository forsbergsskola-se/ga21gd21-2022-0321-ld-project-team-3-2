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
    private Animator textAnim;
    
    private void Start()
    {
        textAnim = GetComponent<Animator>();
        clickSoundInstance = FMODUnity.RuntimeManager.CreateInstance(clickSoundPlaceEventHere);
    }
    
    
    
    public void StartGame()
    {
        clickSoundInstance.start();
        StartCoroutine(StartMenuText());
    }

    IEnumerator StartMenuText()
    {
        textAnim.SetTrigger("start");
        yield return new WaitForSeconds(textScrollTime);
        textAnim.SetTrigger("stop");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadSceneAsync(sceneIndexToLoad);
    }
    
    public void ExitGame()
    {   
        clickSoundInstance.start();
        Application.Quit();
    }
}
