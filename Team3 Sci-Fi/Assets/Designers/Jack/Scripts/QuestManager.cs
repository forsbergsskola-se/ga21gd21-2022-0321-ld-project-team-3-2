using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private QuestWaypoint cw;
    [SerializeField] private KeyPadPower keyPad;
    [SerializeField] private KeyPadPower2 keyPad2;

    public bool killedHabitant;
    public bool hasBomb;

    private void Update()
    {
        PuzzleOneQuest();
        PuzzleTwoQuest();
    }

    private void PuzzleOneQuest()
    {
        if(keyPad.correctCode)
        {
            while (cw.targetArrayValue <= 3)
            {
                cw.targetArrayValue++;
                cw.activeQuestArrayValue++;
            }

            keyPad.correctCode = false;
        }
    }

    private void PuzzleTwoQuest()
    {
        if(keyPad2.correctCodePuzzle2)
        {
            while (cw.activeQuestArrayValue <= 7)
            {
                cw.activeQuestArrayValue++;
            }
            while (cw.targetArrayValue <= 6)
            {
                cw.targetArrayValue++;
            }

            keyPad2.correctCodePuzzle2 = false;
        }
    }
}
