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
        float minX = questMarker.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        
        float minY = questMarker.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.width - minY;
        
        Vector2 pos = Camera.main.WorldToScreenPoint(target.position);

        if(Vector3.Dot((target.position - transform.position), transform.forward) < 0)
        {
            if(pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }
        
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        
        questMarker.transform.position = pos;

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
