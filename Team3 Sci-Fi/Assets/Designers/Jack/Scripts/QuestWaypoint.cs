using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestWaypoint : MonoBehaviour
{
    public Image questMarker;
    [SerializeField] private Transform[] target = new Transform[5];
    [HideInInspector] public int targetArrayValue;
    [SerializeField] private string[] activeQuestString = new string[10];
    [HideInInspector] public int activeQuestArrayValue;
    
    public TMP_Text meter;
    public TMP_Text activeQuest;

    private void Start()
    {
        questMarker.enabled = false;
        meter.enabled = false;
    }

    void Update()
    {
        float minX = questMarker.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        
        float minY = questMarker.GetPixelAdjustedRect().height / 2;
        float maxY = Screen.width - minY;
        
        Vector2 pos = Camera.main.WorldToScreenPoint(target[targetArrayValue].position);

        if(Vector3.Dot((target[targetArrayValue].position - transform.position), transform.forward) < 0)
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
        meter.text = ((int)Vector3.Distance(target[targetArrayValue].position, transform.position)).ToString() + " m";

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(ToggleQuestMarker());
        }
    }

    IEnumerator ToggleQuestMarker()
    {
        questMarker.enabled = true;
        meter.enabled = true;
        activeQuest.enabled = true;
        yield return new WaitForSeconds(4);
        questMarker.enabled = false;
        meter.enabled = false;
        activeQuest.enabled = false;
    }
}
