using System;
using UnityEngine;
using UnityEngine.Events;

public class OLDDialogueTrigger : MonoBehaviour {

    public LayerMask PlayerLayer;
    public OLDDialogue oldDialogue;
    public GameObject face;
    [SerializeField] private float dialogueRange = 10f;
    private bool isInDialogueRange;
    private OLDDialogueManager _oldDialogueManager;

    private void Start()
    {
        _oldDialogueManager = FindObjectOfType<OLDDialogueManager>();
    }

    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.F))
        {
            return;
        }
        isInDialogueRange = Physics.CheckSphere(transform.position, dialogueRange, PlayerLayer);

        if (isInDialogueRange && !_oldDialogueManager.isInDialogue)
        {
            _oldDialogueManager.isInDialogue = true;
            TriggerDialogue();
        }
        else if (_oldDialogueManager.isInDialogue && !_oldDialogueManager.inChoice)
        {
            _oldDialogueManager.DisplayNextSentence();
        }


    }

    private void TriggerDialogue ()
    {
        _oldDialogueManager.StartDialogue(oldDialogue);
        face.SetActive(true);
    }

}
