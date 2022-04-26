 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OLDDialogueManager : MonoBehaviour {

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject continueText;
    public TextMeshProUGUI answer1Text;
    public TextMeshProUGUI answer2Text;

    public Animator animator;
    public GameObject choices;

    private Queue<string> sentences;
    private Queue<string> altSentences;
    private Queue<bool> choiceTriggers;
    
    public bool isInDialogue;
    private bool isThisAnswer1 = true;
    public bool inChoice;
    // Use this for initialization
    void Start () {
        sentences = new Queue<string>();
        altSentences = new Queue<string>();
        choiceTriggers = new Queue<bool>();
    }

    public void StartDialogue (OLDDialogue oldDialogue)
    {
        animator.SetBool("IsOpen", true);
        continueText.SetActive(true);
        nameText.text = oldDialogue.name;
        answer1Text.text = oldDialogue.answer1;
        answer2Text.text = oldDialogue.answer2;

        isThisAnswer1 = true;
        sentences.Clear();
        choiceTriggers.Clear();
        altSentences.Clear();

        foreach (string sentence in oldDialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (var sentence in oldDialogue.answer2Sentences)
        {
            altSentences.Enqueue(sentence);
        }
        foreach (var choice in oldDialogue.multipleChoiceTriggers)
        {
            choiceTriggers.Enqueue(choice);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence ()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        string sentence = sentences.Dequeue();
        string sentenceAlt = altSentences.Dequeue();
        bool isChoice = choiceTriggers.Dequeue();
        StopAllCoroutines();
        
        if (!isThisAnswer1)
        {
            StartCoroutine(TypeSentence(sentenceAlt));
        }
        else
        {
            StartCoroutine(TypeSentence(sentence));
        }
        
        if (isChoice)
        {
            continueText.SetActive(false);
            inChoice = true;
            choices.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            FindObjectOfType<MouseLook>().enabled = false;
        }
    }

    IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        FindObjectOfType<OLDDialogueTrigger>().face.SetActive(false);
        isInDialogue = false;
        continueText.SetActive(false);
    }

    public void Answer1()
    {
        isThisAnswer1 = true;
        continueText.SetActive(true);
        inChoice = false;
        choices.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<MouseLook>().enabled = true;
        DisplayNextSentence();
    }

    public void Answer2()
    {
        isThisAnswer1 = false;
        continueText.SetActive(true);
        inChoice = false;
        choices.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        FindObjectOfType<MouseLook>().enabled = true;
        DisplayNextSentence();
    }

}

