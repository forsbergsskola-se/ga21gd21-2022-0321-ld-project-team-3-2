using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private ChangeWaypoint qw;
    [SerializeField] private ChangeActiveQuest qa;
    [SerializeField] private GameObject waypoint;
    [SerializeField] private GameObject activeQuest;
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(TimerStart());
    }
    
    IEnumerator TimerStart()
    {
        waypoint.SetActive(false);
        activeQuest.SetActive(false);
        yield return new WaitForSeconds(60);
        waypoint.SetActive(true);
        activeQuest.SetActive(true);
        qw.IncramentWaypointExternal();
        qa.IncramentActiveQuestExternal();
    }
}
