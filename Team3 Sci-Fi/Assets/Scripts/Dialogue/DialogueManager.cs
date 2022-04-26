using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    /*
        Modify in order to meet these criteria
        
        - player and npc can each talk extended periods without triggering choices, works
        - Trigger choices whenever we want, works
        - Player and npc can talk full size, works
        - Dialogue length should be adjustable, works
        - Toggleable multiple choice conversation, works
        - Return after dialogue message, works

        to do:
        - Implement faces
        - Separate into manager and trigger scripts
    */
   
    public ChoiceDialogue choiceDialogue;
    public SimpleDialogue SimpleDialogue;
    private bool isSimpleDialogue;
    private bool isTalking;
    public float dialogueRange;
    public LayerMask PlayerLayer;
    public GameObject dialogueUI;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI speechText;
    public TextMeshProUGUI answer1Text;
    public TextMeshProUGUI answer2Text;
    public GameObject choices;
    public Image icon;

    private int dialogueTracker = 0;

    private bool dialogueFinished;
    private bool returnDialogueRead;
    private bool inChoice;

    private int answerNum = 0;
    
    void Start()
    {
        dialogueUI.SetActive(false);
        if (choiceDialogue == null) isSimpleDialogue = true;
        else
        {
            isSimpleDialogue = false;
        }
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.F))
        {
            return;
        }

        if (Physics.CheckSphere(transform.position, dialogueRange, PlayerLayer) && !isTalking)
        {
            StartDialogue();
        }
        else if (isTalking)
        {
            if (dialogueFinished)
            {
                DisplayReturnMessage();
            }
            else if (isSimpleDialogue)
            {
                DisplayNextSentenceSimple();
            }
            else if (!inChoice)
            {
                DisplayNextSentenceChoice();
            }
        }
    }

    void StartDialogue()
    {
        isTalking = true;
        dialogueUI.SetActive(true);

        if (dialogueFinished)
        {
            returnDialogueRead = false;
            DisplayReturnMessage();
        }
        else if (isSimpleDialogue)
        {
            DisplayNextSentenceSimple();
        }
        else
        {
            answer1Text.text = choiceDialogue.answer1;
            answer2Text.text = choiceDialogue.answer2;
            DisplayNextSentenceChoice();
        }
    }
    
    public void DisplayNextSentenceSimple()
    {
        if (dialogueTracker >= SimpleDialogue.lines.Length)
        {
            EndDialogue();
            return;
        }
        
        nameText.text = SimpleDialogue.lines[dialogueTracker].character.name;
        icon.sprite = SimpleDialogue.lines[dialogueTracker].character.icon;

        string sentence = SimpleDialogue.lines[dialogueTracker].text;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        
        dialogueTracker++;
    }

    public void DisplayNextSentenceChoice()
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
            FindObjectOfType<MouseLook>().enabled = false;
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
        FindObjectOfType<MouseLook>().enabled = true;
        DisplayNextSentenceChoice();
    }
    public void Answer2()
    {
        answerNum = 2;
        dialogueTracker = 0;
        inChoice = false;
        choices.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<MouseLook>().enabled = true;
        DisplayNextSentenceChoice();
    }
    
    
    public void DisplayReturnMessage()
    {
        if (returnDialogueRead)
        {
            EndDialogue();
            return;
        }
        string sentence;
        if (isSimpleDialogue)
        {
            nameText.text = SimpleDialogue.onReturnDialogue.character.name;
            icon.sprite = SimpleDialogue.onReturnDialogue.character.icon;
            sentence = SimpleDialogue.onReturnDialogue.text;
        }
        else
        {
            nameText.text = choiceDialogue.onReturnDialogue.character.name;
            icon.sprite = choiceDialogue.onReturnDialogue.character.icon;
            sentence = choiceDialogue.onReturnDialogue.text;
        }
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        returnDialogueRead = true;
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
    
    
    

    void EndDialogue()
    {
        dialogueFinished = true;
        answerNum = 0;
        isTalking = false;
        dialogueUI.SetActive(false);
        dialogueTracker = 0;
    }
    
    
}
