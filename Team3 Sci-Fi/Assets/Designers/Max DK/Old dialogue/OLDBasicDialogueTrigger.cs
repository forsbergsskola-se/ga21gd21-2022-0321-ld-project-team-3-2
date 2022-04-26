using System;
using UnityEngine;
using UnityEngine.Events;

public class OLDBasicDialogueTrigger : MonoBehaviour {

    public LayerMask PlayerLayer;
    public OLDDialogueBasic oldDialogue;
    public GameObject face;
    [SerializeField] private float dialogueRange = 10f;
    private bool isInDialogueRange;
    private OLDBasicDialogueManager dialogueManager;

    private void Start()
    {
        dialogueManager = FindObjectOfType<OLDBasicDialogueManager>();
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
        dialogueManager.StartDialogue(oldDialogue);
        face.SetActive(true);
    }

}
