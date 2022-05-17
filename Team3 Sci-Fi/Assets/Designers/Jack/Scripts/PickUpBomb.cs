using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickUpBomb : MonoBehaviour
{

    [SerializeField] private QuestManager qm;
    [SerializeField] private GameObject bomb;
    
    public bool withinRange;
    private void OnTriggerEnter(Collider other)
    {
        withinRange = true;
    }

    private void Update()
    {
        if (!withinRange)
        {
            return;
        }

        PickUp();
    }

    private void PickUp()
    {
        if (withinRange && Input.GetKeyDown(KeyCode.E))
        {
            qm.hasBomb = true;
            Destroy(bomb);
        }
    }
}
