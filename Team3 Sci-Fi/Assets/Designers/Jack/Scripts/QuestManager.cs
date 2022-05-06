using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    [SerializeField] private QuestWaypoint cw;
    [SerializeField] private KeyPadPower keyPad;

    private void Update()
    {
        PuzzleOneQuest();
    }

    private void PuzzleOneQuest()
    {
        if (keyPad.correctCode)
        {
            while (cw.targetArrayValue <= 1)
            {
                cw.targetArrayValue++;
                cw.activeQuestArrayValue++;
            }

            keyPad.correctCode = false;
        }
    }
}
