using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OpenStories : MonoBehaviour
{
    [SerializeField] private InteractionManager interact;
    [SerializeField] private CharacterController movement;
    [SerializeField] private MouseLook mouse;
    [SerializeField] private GameObject story;
    [SerializeField] private TMP_Text text;
    

    private bool withinRange;
    private bool isReading;
    [TextArea(10, 10)] public string storyText;
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
            movement.enabled = false;
            Cursor.lockState = CursorLockMode.None;
            mouse.enabled = false;
            isReading = true;
            story.SetActive(true);
            text.text = storyText;
        }
        else if (Input.GetKeyDown(KeyCode.E) && isReading)
        {
            isReading = false;
            movement.enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            mouse.enabled = true;
            story.SetActive(false);
        }
    }
}
