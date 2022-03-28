using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    
    public LayerMask PlayerLayer;
    public GameObject interactionBox;
    [SerializeField] private float interactionRange = 10f;
    private bool isInInteractRange;
   
    
    void Update()
    {
        isInInteractRange = Physics.CheckSphere(transform.position, interactionRange, PlayerLayer);

        interactionBox.SetActive(isInInteractRange);
    }
}
