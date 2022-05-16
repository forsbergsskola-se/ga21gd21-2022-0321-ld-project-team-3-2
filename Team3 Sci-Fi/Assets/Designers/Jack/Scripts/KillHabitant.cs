using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillHabitant : MonoBehaviour
{
    [SerializeField] private InteractionManager interact;
    [SerializeField] private GameObject kahirNotKillDialogueTrigger;
    [SerializeField] private GameObject kahirKillDialogueTrigger;
    [SerializeField] private GameObject screamTrigger;
    [SerializeField] private QuestManager qm;

    public bool withinRange;
    private void OnTriggerEnter(Collider other)
    {
        interact.ShowInteractMessage("Press E to turn  off generator");
        withinRange = true;
    }
    private void OnTriggerExit(Collider other)
    {
        interact.HideInteractMessage();
        withinRange = false;
        
    }
    
    private void Update()
    {
        if (!withinRange)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            TurnOffGenerator();
        }
    }

    private void TurnOffGenerator()
    {
        qm.killedHabitant = true;
        kahirNotKillDialogueTrigger.SetActive(false);
        kahirKillDialogueTrigger.SetActive(true);
        screamTrigger.SetActive(true);
        Destroy(this);
    }
}
