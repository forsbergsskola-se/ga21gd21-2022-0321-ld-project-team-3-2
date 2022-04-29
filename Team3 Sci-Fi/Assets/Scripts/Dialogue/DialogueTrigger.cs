using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask PlayerLayer;
    private DialogueManager dialogueManager;
    public ChoiceDialogue choiceDialogue;
    
    void Start()
    {
        choiceDialogue.isDialogueFinishedChoice = false;
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    
    void Update()
    {
        if (Physics.CheckSphere(transform.position, dialogueRange, PlayerLayer))
        {
            if (Input.GetKeyDown(KeyCode.E))
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
        }
    }
}
