using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public float dialogueRange;
    private DialogueManager dialogueManager;
    public ChoiceDialogue choiceDialogue;
    private float distance;
    private GameObject player;
    
    
    
    void Start()
    {
        player = FindObjectOfType<Movement>().gameObject;
        choiceDialogue.isDialogueFinishedChoice = false;
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
        
        if (distance <= dialogueRange && dialogueManager.isTalking && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueManager.inChoice && choiceDialogue.isDialogueFinishedChoice)
            {
                dialogueManager.DisplayReturnMessage();
            }
            else if (!dialogueManager.inChoice && !choiceDialogue.isDialogueFinishedChoice)
            {
                dialogueManager.DisplayNextSentenceChoice();
            }
        }
        // else if (distance > dialogueRange && dialogueManager.isTalking)
        // {
        //     dialogueManager.CancelDialogue();
        // }
    }

    
    private void OnMouseOver()
    {
        
        if (distance <= dialogueRange && Input.GetKeyDown(KeyCode.E))
        {
            if (!dialogueManager.isTalking && !choiceDialogue.isDialogueFinishedChoice)
            {
                dialogueManager.StartDialogue(choiceDialogue);
            }
            else if (!dialogueManager.isTalking && choiceDialogue.isDialogueFinishedChoice)
            {
                dialogueManager.StartReturnMessageDialogue(choiceDialogue);
            }
            
        }
        
    }
}
