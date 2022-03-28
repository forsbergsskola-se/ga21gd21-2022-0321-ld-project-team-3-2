using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour {

    public LayerMask PlayerLayer;
    public Dialogue dialogue;
    public GameObject face;
    [SerializeField] private float dialogueRange = 10f;
    private bool isInDialogueRange;

    private void Update()
    {
        isInDialogueRange = Physics.CheckSphere(transform.position, dialogueRange, PlayerLayer);

        if (isInDialogueRange && Input.GetKey(KeyCode.F))
        {
            TriggerDialogue();
        }

        if (isInDialogueRange && Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<DialogueManager>().DisplayNextSentence();
        }

      
    }

    private void TriggerDialogue ()
    {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        face.SetActive(true);
    }

}
