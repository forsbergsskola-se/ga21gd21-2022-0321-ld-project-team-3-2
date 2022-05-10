using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Serialization;

public class QuestPuzzle2 : MonoBehaviour
{
    [SerializeField] public Image[] waypoint = new Image[4];
    [SerializeField] public Transform[] target = new Transform[4];
    
    public TMP_Text[] meter = new TMP_Text[4];

    private void Start()
    {
        enabled = false;
    }

    private void Update()
    {
        QuestMarkerOne();
        QuestMarkerTwo();
        QuestMarkerThree();
        QuestMarkerFour();
    }

    public void QuestMarkerOne()
    {
        float minX = waypoint[0].GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        
        float minY = waypoint[0].GetPixelAdjustedRect().height / 2;
        float maxY = Screen.width - minY;
        
        Vector2 pos = Camera.main.WorldToScreenPoint(target[0].position);

        if(Vector3.Dot((target[0].position - transform.position), transform.forward) < 0)
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
        
        waypoint[0].transform.position = pos;
        meter[0].text = (int)Vector3.Distance(target[0].position, transform.position) + " m";
    }
    
    public void QuestMarkerTwo()
    {
        float minX = waypoint[1].GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        
        float minY = waypoint[1].GetPixelAdjustedRect().height / 2;
        float maxY = Screen.width - minY;
        
        Vector2 pos = Camera.main.WorldToScreenPoint(target[1].position);

        if(Vector3.Dot((target[1].position - transform.position), transform.forward) < 0)
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
        
        waypoint[1].transform.position = pos;
        meter[1].text = (int)Vector3.Distance(target[1].position, transform.position) + " m";
    }
    
    public void QuestMarkerThree()
    {
        float minX = waypoint[2].GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        
        float minY = waypoint[2].GetPixelAdjustedRect().height / 2;
        float maxY = Screen.width - minY;
        
        Vector2 pos = Camera.main.WorldToScreenPoint(target[2].position);

        if(Vector3.Dot((target[2].position - transform.position), transform.forward) < 0)
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
        
        waypoint[2].transform.position = pos;
        meter[2].text = (int)Vector3.Distance(target[2].position, transform.position) + " m";
    }
    
    public void QuestMarkerFour()
    {
        float minX = waypoint[3].GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        
        float minY = waypoint[3].GetPixelAdjustedRect().height / 2;
        float maxY = Screen.width - minY;
        
        Vector2 pos = Camera.main.WorldToScreenPoint(target[3].position);

        if(Vector3.Dot((target[3].position - transform.position), transform.forward) < 0)
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
        
        waypoint[3].transform.position = pos;
        meter[3].text = (int)Vector3.Distance(target[3].position, transform.position) + " m";
    }
}
