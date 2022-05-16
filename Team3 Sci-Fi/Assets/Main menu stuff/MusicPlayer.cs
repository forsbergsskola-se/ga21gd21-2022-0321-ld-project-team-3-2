using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{



    [Header("This script lets the attached fmod event")]
    [Header("continue playing when loading the next scene")]
    [Header("if you want your sound to only play in this scene")]
    [Header("remove/dont use this script here")]
    [Header("")]

    public bool useThisScript;
    
    
    public static MusicPlayer instance;
    
    void Awake()
    {
        if (useThisScript)
        {
            if (instance != null)
                Destroy(gameObject);
            else
            {
                instance = this;
                DontDestroyOnLoad(this.gameObject);
            }
        }
    }
}
