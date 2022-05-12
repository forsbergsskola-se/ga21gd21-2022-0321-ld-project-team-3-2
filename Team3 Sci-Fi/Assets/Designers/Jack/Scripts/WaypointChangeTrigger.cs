using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointChangeTrigger : MonoBehaviour
{  
    [SerializeField] private Collider thisColl;
    [SerializeField] public ChangeWaypoint cw;
    private void OnTriggerEnter(Collider other)
    {
        cw.IncramentWaypointExternal();
        thisColl.enabled = false;
    }
}
