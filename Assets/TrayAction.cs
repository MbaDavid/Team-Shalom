using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayAction : MonoBehaviour
{
    public CollisionTAG colliderTag;

    public List<Transform> dropPoints;

    int i = 0;



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(colliderTag.ToString()))
        {
            if (QuestManager.Main.currentQuestIndex != 4)
                return;

            other.transform.position = dropPoints[i].position;
            i++;

        }


    }
}
