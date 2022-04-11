 using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BasicDialogueManager : MonoBehaviour {

    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public GameObject continueText;

    public Animator animator;

    private Queue<string> sentences;
    
    public bool isInDialogue;
    
    // Use this for initialization
    void Start () 
    {
        sentences = new Queue<string>();
    }

    public void StartDialogue (DialogueBasic dialogue)
    {
        animator.SetBool("IsOpen", true);
        continueText.SetActive(true);
        nameText.text = dialogue.name;

        sentences.Clear();
        
        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
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
        
        StopAllCoroutines();
        
        StartCoroutine(TypeSentence(sentence));
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
        FindObjectOfType<DialogueTrigger>().face.SetActive(false);
        isInDialogue = false;
        continueText.SetActive(false);
    }
}

