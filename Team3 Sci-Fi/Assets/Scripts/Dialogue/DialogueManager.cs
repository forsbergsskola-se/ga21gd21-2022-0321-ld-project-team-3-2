using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private ChoiceDialogue choiceDialogue;
    public GameObject dialogueUI;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI answer1Text;
    public TextMeshProUGUI answer2Text;
    public GameObject choices;
    public Image icon;
    public MouseLook mouseLook;
    public InteractionManager interact;
    public GameObject choiceText;
    public GameObject continueText;
    
    private int dialogueTracker;
    [HideInInspector] public bool inChoice;
    [HideInInspector] public bool isTalking;
    private int answerNum = 0;
    private bool isInMessage;

    public float timeBetweenLetters;

   


    void Start()
    {
        dialogueTracker = 0;
        dialogueUI.SetActive(false);
    }

    public void StartDialogue(ChoiceDialogue choiceDia)
    {
        choiceDialogue = choiceDia;
        choiceDialogue.isDialogueFinished = false;
       
        
        isTalking = true;
        interact.HideInteractMessage();
        dialogueUI.SetActive(true);

        
        answer1Text.text = choiceDialogue.answer1;
        answer2Text.text = choiceDialogue.answer2;
        DisplayNextSentenceChoice();
    }

    public void StartReturnMessageDialogue(ChoiceDialogue choice)
    {
        
        choiceDialogue = choice;
       
        isTalking = true;
        interact.HideInteractMessage();
        dialogueUI.SetActive(true);
        Debug.Log("is this happening 1");
        DisplayReturnMessage();
    }
    

    public void DisplayNextSentenceChoice()
    {
        Debug.Log("is this happening 4");
        if (choiceDialogue.linesInitial.Length == 1)
        {
            DisplayReturnMessage();
            return;
        }
        
        if (answerNum == 1 && dialogueTracker >= choiceDialogue.linesBranch1.Length)
        {
            EndDialogue();
            return;
        }
        if (answerNum == 2 && dialogueTracker >= choiceDialogue.linesBranch2.Length)
        {
            EndDialogue();
            return;
        }
        if (answerNum == 0 && dialogueTracker >= choiceDialogue.linesInitial.Length)
        {
            EndDialogue();
            return;
        }
        
        Debug.Log("triggerZone debug");

        string sentence;
        
        if (answerNum == 1)
        {
            nameText.text = choiceDialogue.linesBranch1[dialogueTracker].character.name;
            icon.sprite = choiceDialogue.linesBranch1[dialogueTracker].character.icon;
            sentence = choiceDialogue.linesBranch1[dialogueTracker].text;
        }
        else if (answerNum == 2)
        {
            nameText.text = choiceDialogue.linesBranch2[dialogueTracker].character.name;
            icon.sprite = choiceDialogue.linesBranch2[dialogueTracker].character.icon;
            sentence = choiceDialogue.linesBranch2[dialogueTracker].text;
        }
        else
        {
            nameText.text = choiceDialogue.linesInitial[dialogueTracker].character.name;
            icon.sprite = choiceDialogue.linesInitial[dialogueTracker].character.icon;
            sentence = choiceDialogue.linesInitial[dialogueTracker].text;
        }
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        if (answerNum == 0 && choiceDialogue.linesInitial[dialogueTracker].isChoiceTrigger)
        {
            continueText.SetActive(false);
            choiceText.SetActive(true);
            inChoice = true;
            choices.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            mouseLook.enabled = false;
        }
        dialogueTracker++;
        
    }

    public void Answer1()
    {
        continueText.SetActive(true);
        choiceText.SetActive(false);
        answerNum = 1;
        dialogueTracker = 0;
        inChoice = false;
        choices.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        mouseLook.enabled = true;
        DisplayNextSentenceChoice();
    }
    public void Answer2()
    {
        continueText.SetActive(true);
        choiceText.SetActive(false);
        answerNum = 2;
        dialogueTracker = 0;
        inChoice = false;
        choices.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        mouseLook.enabled = true;
        DisplayNextSentenceChoice();
    }
    
    
    public void DisplayReturnMessage()
    {
        if (isInMessage)
        {
            Debug.Log("is this happening 2");
            EndDialogue();
            isInMessage = false;
            return;
        }
        Debug.Log("is this happening 3");
        string sentence;
        
        nameText.text = choiceDialogue.onReturnDialogue.character.name;
        icon.sprite = choiceDialogue.onReturnDialogue.character.icon;
        sentence = choiceDialogue.onReturnDialogue.text;
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
        isInMessage = true;
    }

    IEnumerator TypeSentence (string sentence)
    {
        speechText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            speechText.text += letter;
            yield return new WaitForSeconds(timeBetweenLetters);
        }
    }
    public void CancelDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
        dialogueTracker = 0;
        answerNum = 0;
        inChoice = false;
        choices.SetActive(false);
        if (Cursor.lockState == CursorLockMode.None)
        {
            Cursor.lockState = CursorLockMode.Locked;
            mouseLook.enabled = true;
        }
    }
    
    public void EndDialogue()
    {
        choiceDialogue.isDialogueFinished = true;
        answerNum = 0;
        isTalking = false;
        dialogueUI.SetActive(false);
        dialogueTracker = 0;
        choiceDialogue.talking = false;
    }
}
