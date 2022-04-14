using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewDialogueManager : MonoBehaviour
{
    public NPC npc;

    private bool isTalking;

    public float dialogueRange;
    public LayerMask PlayerLayer;
    private int currentResponseTracker = 0;

    public GameObject player;
    public GameObject dialogueUI;

    public Text npcName;
    public Text npcDialogueBox;
    public Text playerResponse;
    
    
    void Start()
    {
        dialogueUI.SetActive(false);
    }

    private void Update()
    {
        if (isTalking && Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            currentResponseTracker++;
            if (currentResponseTracker >= npc.playerDialogue.Length - 1)
            {
                currentResponseTracker = npc.playerDialogue.Length - 1;
            }
        }
        else if (isTalking && Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            currentResponseTracker--;
            if (currentResponseTracker < 0)
            {
                currentResponseTracker = 0;
            }
        }

        if (currentResponseTracker == 0 && npc.playerDialogue.Length >= 0)
        {
            playerResponse.text = npc.playerDialogue[0];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                npcDialogueBox.text = npc.dialogue[1];
            }
        }
        else if (currentResponseTracker == 1 && npc.playerDialogue.Length >=1)
        {
            playerResponse.text = npc.playerDialogue[1];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                npcDialogueBox.text = npc.dialogue[2];
            }
        }
        else if (currentResponseTracker == 2 && npc.playerDialogue.Length >=2)
        {
            playerResponse.text = npc.playerDialogue[2];
            if (Input.GetKeyDown(KeyCode.Return))
            {
                npcDialogueBox.text = npc.dialogue[3];
            }
        }
        
        if (!Input.GetKeyDown(KeyCode.F))
        {
            return;
        }

        if (Physics.CheckSphere(transform.position, dialogueRange, PlayerLayer) && !isTalking)
        {
            StartConversation();
        }
        else if (isTalking)
        {
            EndDialogue();
        }
    }

    void StartConversation()
    {
        isTalking = true;
        currentResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
    }
    
    
}
