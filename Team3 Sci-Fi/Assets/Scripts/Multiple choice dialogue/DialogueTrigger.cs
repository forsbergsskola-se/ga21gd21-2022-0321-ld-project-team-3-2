using System;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour {

    public LayerMask PlayerLayer;
    public Dialogue dialogue;
    public GameObject face;
    [SerializeField] private float dialogueRange = 10f;
    private bool isInDialogueRange;
    private DialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<DialogueManager>();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.F))
        {
            return;
        }
        isInDialogueRange = Physics.CheckSphere(transform.position, dialogueRange, PlayerLayer);

        if (isInDialogueRange && !dialogueManager.isInDialogue)
        {
            dialogueManager.isInDialogue = true;
            TriggerDialogue();
        }
        else if (dialogueManager.isInDialogue && !dialogueManager.inChoice)
        {
            dialogueManager.DisplayNextSentence();
        }


    }

    private void TriggerDialogue ()
    {
        dialogueManager.StartDialogue(dialogue);
        face.SetActive(true);
    }

}
