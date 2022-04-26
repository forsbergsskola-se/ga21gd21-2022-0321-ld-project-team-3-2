using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask PlayerLayer;
    private DialogueManager dialogueManager;
    public ChoiceDialogue choiceDialogue;
    public SimpleDialogue SimpleDialogue;
    private bool isSimpleDialogue;
    void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
        if (choiceDialogue == null) isSimpleDialogue = true;
        else
        {
            isSimpleDialogue = false;
        }
    }

   
    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.F))
        {
            return;
        }

        if (Physics.CheckSphere(transform.position, dialogueRange, PlayerLayer) && !dialogueManager.isTalking)
        {
            dialogueManager.StartDialogue(SimpleDialogue,choiceDialogue);
        }
        else if (dialogueManager.isTalking)
        {
            if (dialogueManager.dialogueFinished)
            {
                dialogueManager.DisplayReturnMessage();
            }
            else if (isSimpleDialogue)
            {
                dialogueManager.DisplayNextSentenceSimple();
            }
            else if (!dialogueManager.inChoice)
            {
                dialogueManager.DisplayNextSentenceChoice();
            }
        }
    }
}
