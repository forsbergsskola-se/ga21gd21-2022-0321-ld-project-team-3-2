using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Quest Array", menuName = "Quest Array")]
public class QuestArrays : ScriptableObject
{
    [SerializeField] public Transform[] target = new Transform[5];
    [SerializeField] public string[] activeQuestString = new string[10];
}
