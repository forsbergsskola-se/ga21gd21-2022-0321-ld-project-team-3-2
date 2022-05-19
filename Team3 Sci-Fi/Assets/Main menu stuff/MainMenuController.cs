using System;
using System.Collections;
using System.Collections.Generic;
using FMODUnity;
using UnityEngine;
using UnityEngine.SceneManagement;
using STOP_MODE = FMOD.Studio.STOP_MODE;

public class MainMenuController : MonoBehaviour
{

    public GameObject musicObject;
    public float textScrollTime;
    public FMODUnity.EventReference clickSoundPlaceEventHere;
    private FMOD.Studio.EventInstance clickSoundInstance;
    public int sceneIndexToLoad;
    private Animator textAnim;
    private FMOD.Studio.EventInstance pauseSnapshot;
    
    private void Start()
    {
        pauseSnapshot = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Esq M");
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
        pauseSnapshot.stop(STOP_MODE.IMMEDIATE);
        Destroy(musicObject);
        SceneManager.LoadSceneAsync(sceneIndexToLoad);
    }
    
    public void ExitGame()
    {   
        clickSoundInstance.start();
        Application.Quit();
    }
}
