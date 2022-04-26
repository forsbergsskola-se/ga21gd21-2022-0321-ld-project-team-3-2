using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OLDDialogue {

    public string name;

    [TextArea(3, 10)] public string[] sentences;
    
    [TextArea(3, 10)] public string[] answer2Sentences;

    public bool[] multipleChoiceTriggers;

    public string answer1;
    public string answer2;
}
