using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using FMOD.Studio;

public class Ending4Text : MonoBehaviour
{

    [SerializeField] private TMP_Text[] text;
    [SerializeField] private Animator anim;
    private EventInstance typingSounds; 
    [TextArea(3, 10)] public string[] storyText = new string[10];
    [TextArea(3, 10)] public string[] storyTextTwo = new string[10];
    private int index;
    public float waitForSeconds = 0.03f;
    void Start()
    {
        typingSounds = FMODUnity.RuntimeManager.CreateInstance("event:/Dialog/Typing sound");
        StartCoroutine(TypeSentence(storyText));
    }

    
    IEnumerator TypeSentence (string[] sentence)
    {
        yield return new WaitForSeconds(5);
        for (int i = 0; i < text.Length; i++)
        {
            text[i].text = "";
            typingSounds.start();
            foreach (char letter in sentence[index].ToCharArray())
            {
                text[i].text += letter;
                yield return new WaitForSeconds(waitForSeconds);
            }
            index++;
            typingSounds.stop(STOP_MODE.IMMEDIATE);
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(2.5f);
        anim.SetTrigger("Fade Out");
        yield return new WaitForSeconds(1);
        for (int i = 0; i < text.Length; i++)
        {
            text[i].text = "";
        }

        index = 0;
        anim.SetTrigger("Fade In");
        StartCoroutine(TypeSentenceTwo(storyTextTwo));
    }
    
    IEnumerator TypeSentenceTwo (string[] sentence)
    {
        yield return new WaitForSeconds(2);
        for (int i = 0; i < text.Length; i++)
        {
            text[i].text = "";
            typingSounds.start();
            foreach (char letter in sentence[index].ToCharArray())
            {
                text[i].text += letter;
                yield return new WaitForSeconds(waitForSeconds);
            }
            index++;
            typingSounds.stop(STOP_MODE.IMMEDIATE);
            yield return new WaitForSeconds(1);
        }

        yield return new WaitForSeconds(5);
        anim.SetTrigger("Fade Out");
        
        //PLAY GAME NAME
    }
}
