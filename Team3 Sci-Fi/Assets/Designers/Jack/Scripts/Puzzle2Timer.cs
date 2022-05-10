using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puzzle2Timer : MonoBehaviour
{

    [SerializeField] private QuestPuzzle2 waypoints;
    private Collider thisColl;
    [SerializeField] private int waitForSeconds;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(StartTimer());
        Debug.Log("Timer Started");
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(waitForSeconds);
        waypoints.enabled = true;
    }
}
