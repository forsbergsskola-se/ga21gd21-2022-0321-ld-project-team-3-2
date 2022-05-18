using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueTriggerZoneEnd : MonoBehaviour
{
    private Collider thisColl;
    private DialogueManager dialogueManager;
    public ChoiceDialogue choiceDialogue;
    public int endSceneToLoadIndex;
    public Animator blackScreenAnim;
    private QuestManager qm;
    void Start()
    {
        qm = FindObjectOfType<QuestManager>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        thisColl = GetComponent<Collider>();
        choiceDialogue.isDialogueFinished = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        dialogueManager.StartDialogue(choiceDialogue);
        choiceDialogue.talking = true;
        thisColl.enabled = false;
    }

    void Update()
    {
        if (dialogueManager.isTalking && Input.GetKeyDown(KeyCode.E) && choiceDialogue.talking && !dialogueManager.inChoice)
        {
            dialogueManager.DisplayNextSentenceChoice();
        }

        if (choiceDialogue.isDialogueFinished)
        {
            StartCoroutine(WaitForEnding());
        }
    }

    IEnumerator WaitForEnding()
    {
        blackScreenAnim.SetTrigger("EndFade");
        yield return new WaitForSeconds(2f);
        
        if (qm.hasBomb)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Endings/Explotion");
        }
        else
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/Endings/Gunz");
        }

        SceneManager.LoadScene(endSceneToLoadIndex);
    }
    
    
}
