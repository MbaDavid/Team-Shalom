using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TrayAction : MonoBehaviour
{
    public CollisionTAG colliderTag;

    public List<Transform> dropPoints;

    public int maxYamCollected = 3;

    private List<GameObject> trayContents = new List<GameObject>();

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

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(colliderTag.ToString()))
        {
            if (QuestManager.Main.currentQuestIndex != 4 || other.GetComponent<ItemBehaviour>().isPlaced || other.GetComponent<ItemBehaviour>().isGrabbed)
                return;

         
            other.GetComponent<Rigidbody>().isKinematic = true;
            Quaternion rotation = other.transform.rotation;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.transform.position = dropPoints[currentIndex].position;
            other.transform.rotation = rotation;
            other.GetComponent<ItemBehaviour>().isPlaced = true;

            other.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            trayContents.Add(other.gameObject);
            currentIndex++;

        }
    }

    public void FreeAllTrayItems()
    {
        for (int i = 0; i < trayContents.Count; i++)
        {
            trayContents[i].GetComponent<XRGrabInteractable>().enabled = true;
            trayContents[i].GetComponent<Rigidbody>().isKinematic = false;
            trayContents[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            trayContents[i].GetComponent<ItemBehaviour>().isPlaced = false;
        }
    }


}
