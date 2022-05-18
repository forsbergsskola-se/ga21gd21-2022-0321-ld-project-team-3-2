using System;
using UnityEngine;

    public class GenerateEnding : MonoBehaviour
    {
        [SerializeField] private GameObject[] endingZone = new GameObject[4];
        [SerializeField] private QuestManager qm;

        private void OnTriggerEnter(Collider other)
        {
            if (qm.hasBomb && qm.killedHabitant)
            {
                endingZone[0].SetActive(true);
            }
            else if (!qm.hasBomb && qm.killedHabitant)
            {
                endingZone[1].SetActive(true);
            }
            else if (!qm.hasBomb && !qm.killedHabitant)
            {
                endingZone[2].SetActive(true);
            }
            else if (qm.hasBomb && !qm.killedHabitant)
            {
                endingZone[3].SetActive(true);
            }
        }
    }
