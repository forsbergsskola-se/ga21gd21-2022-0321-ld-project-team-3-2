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

    public int dialogueTracker;
    public bool inChoice;
    public bool isTalking;
    private int answerNum = 0;
    private bool isInMessage;

   


    void Start()
    {
        dialogueTracker = 0;
        dialogueUI.SetActive(false);
    }

    public void StartDialogue(ChoiceDialogue choiceDia)
    {
        choiceDialogue = choiceDia;
        choiceDialogue.isDialogueFinishedChoice = false;
       
        
        isTalking = true;
        dialogueUI.SetActive(true);

        
        answer1Text.text = choiceDialogue.answer1;
        answer2Text.text = choiceDialogue.answer2;
        DisplayNextSentenceChoice();
    }

    public void StartReturnMessageDialogue(ChoiceDialogue choice)
    {
        
        choiceDialogue = choice;
       
        isTalking = true;
        dialogueUI.SetActive(true);
        
        DisplayReturnMessage();
    }
    

    public void DisplayNextSentenceChoice()
    {
        if (choiceDialogue.linesInitial.Length == 1)
        {
            DisplayReturnMessage();
        }
        else if (choiceDialogue.linesInitial.Length != 1)
        {
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
        }
        

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
            inChoice = true;
            choices.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            mouseLook.enabled = false;
        }
        dialogueTracker++;
        
    }

    public void Answer1()
    {
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
            EndDialogue();
            isInMessage = false;
            return;
        }
        
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
            yield return null;
        }
    }
    public void CancelDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
    }
    
    public void EndDialogue()
    {
        choiceDialogue.isDialogueFinishedChoice = true;
        answerNum = 0;
        isTalking = false;
        dialogueUI.SetActive(false);
        dialogueTracker = 0;
    }
}
