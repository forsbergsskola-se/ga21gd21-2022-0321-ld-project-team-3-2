using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestWaypoint : MonoBehaviour
{
    public Image questMarker;
    public Transform target;

    private void Start()
    {
        questMarker.enabled = false;
    }

    void Update()
    {
        questMarker.transform.position = Camera.main.WorldToScreenPoint(target.position);

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(ToggleQuestMarker());
        }
    }

    IEnumerator ToggleQuestMarker()
    {
        questMarker.enabled = true;
        yield return new WaitForSeconds(4);
        questMarker.enabled = false;
    }
}
