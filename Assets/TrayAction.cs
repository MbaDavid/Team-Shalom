using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrayAction : MonoBehaviour
{
    public CollisionTAG colliderTag;

    public List<Transform> dropPoints;

    public int maxYamCollected = 3;

    int currentIndex = 0;

    private void Update()
    {
        if (QuestManager.Main.currentQuestIndex != 4)
            return;
        if (currentIndex >= maxYamCollected)
        {
            GameManager.Main.PlaceHeadOfYamInTrayQuest();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(colliderTag.ToString()))
        {
            if (QuestManager.Main.currentQuestIndex != 4)
                return;

            other.transform.position = dropPoints[currentIndex].position;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            currentIndex++;

        }


    }
}
