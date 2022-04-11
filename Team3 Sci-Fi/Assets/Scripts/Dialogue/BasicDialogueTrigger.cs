using System;
using UnityEngine;
using UnityEngine.Events;

public class BasicDialogueTrigger : MonoBehaviour {

    public LayerMask PlayerLayer;
    public DialogueBasic dialogue;
    public GameObject face;
    [SerializeField] private float dialogueRange = 10f;
    private bool isInDialogueRange;
    private BasicDialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<BasicDialogueManager>();
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
        else if (dialogueManager.isInDialogue)
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
