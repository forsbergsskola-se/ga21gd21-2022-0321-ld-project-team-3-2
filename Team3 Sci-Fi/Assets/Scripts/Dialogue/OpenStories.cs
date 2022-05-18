using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenStories : MonoBehaviour
{
    [SerializeField] private InteractionManager interact;
    [SerializeField] private CharacterController movement;
    [SerializeField] private MouseLook mouse;
    [SerializeField] private TMP_Text text;
    [SerializeField] private Animator anim;
    public float waitForSeconds;
    

    private bool withinRange;
    private bool isReading;
    [TextArea(10, 10)] public string storyText;
    private FMOD.Studio.EventInstance typingSounds;


    private void Start()
    {
        typingSounds = FMODUnity.RuntimeManager.CreateInstance("event:/Dialog/Typing sound");
    }

    private void OnTriggerEnter(Collider other)
    {
        interact.ShowInteractMessage("Press E to read");
        withinRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        interact.HideInteractMessage();
        withinRange = false;
        
    }
    private void Update()
    {
        if (!withinRange)
        {
            return;
        }
        
        OpenStory();
    }

    public void OpenStory()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isReading)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Player/Items/Quest PickUp");
            movement.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            mouse.enabled = false;
            isReading = true;
            interact.HideInteractMessage();
            anim.SetTrigger("StoriesIn");
            FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Zoop");
            StartCoroutine(TypeSentence(storyText));
        }
        else if (Input.GetKeyDown(KeyCode.E) && isReading)
        {
            isReading = false;
            movement.enabled = true;
            FMODUnity.RuntimeManager.PlayOneShot("event:/Ui/Zoop");
            Cursor.lockState = CursorLockMode.Locked;
            mouse.enabled = true;
            anim.SetTrigger("StoriesOut");
            typingSounds.stop(STOP_MODE.IMMEDIATE);
            StopAllCoroutines();
        }
    }
    
    IEnumerator TypeSentence (string sentence)
    {
        text.text = "";
        typingSounds.start();
        yield return new WaitForSeconds(0.5f);
        foreach (char letter in sentence.ToCharArray())
        {
            text.text += letter;
            yield return new WaitForSeconds(waitForSeconds);
        }
        typingSounds.stop(STOP_MODE.IMMEDIATE);
    }
}
