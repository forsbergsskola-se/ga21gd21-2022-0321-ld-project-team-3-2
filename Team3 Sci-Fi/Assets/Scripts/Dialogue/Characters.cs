using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Character", menuName = "Character Object")]
public class Characters : ScriptableObject
{
    public bool isHaron;
    public bool isKahir;
    public string name;
    public Sprite icon;
}
