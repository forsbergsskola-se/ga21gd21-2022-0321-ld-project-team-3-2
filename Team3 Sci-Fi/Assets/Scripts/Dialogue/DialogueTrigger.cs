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
    
    
    
    private void OnMouseOver()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);
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
            else if (dialogueManager.isTalking)
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
        }
        else if (distance > dialogueRange && dialogueManager.isTalking)
        {
            dialogueManager.CancelDialogue();
        }
    }
}
