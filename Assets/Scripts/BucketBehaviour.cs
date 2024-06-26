using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class BucketBehaviour : MonoBehaviour
{
    public CollisionTAG colliderTag;
    public CollisionTAG trowelTag;

    public Transform dropPoint;

    private GameObject bucketContent;

    private void Update()
    {
        if (QuestManager.Main == null)
            return;
        if (QuestManager.Main.currentQuestIndex == 7)
        {


            if (bucketContent != null)
            {
                GameManager.Main.PlaceSliceOfYamInBucketQuest();
            }

        }



    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(colliderTag.ToString()))
        {
            if (QuestManager.Main.currentQuestIndex != 7 || bucketContent != null || other.GetComponent<ItemBehaviour>().isPlaced || other.GetComponent<ItemBehaviour>().isGrabbed)
                return;


            other.GetComponent<Rigidbody>().isKinematic = true;
            Quaternion rotation = other.transform.rotation;
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.transform.position = dropPoint.position;
            other.transform.rotation = rotation;
            other.GetComponent<ItemBehaviour>().isPlaced = true;

            other.gameObject.GetComponent<XRGrabInteractable>().enabled = false;
            bucketContent = other.gameObject;

        }

        if (other.CompareTag(trowelTag.ToString()) && (QuestManager.Main.currentQuestIndex == 8 || QuestManager.Main.currentQuestIndex == 10) )
        {
   
            if (bucketContent == null)
            {
                ItemBehaviour item = other.GetComponent<ItemBehaviour>();
                if (item != null)
                {
                    item.EnableChildIems();
                }
            }
            else
            {
                if (other.GetComponent<ItemBehaviour>().isFilled) {
                    ItemBehaviour item = other.GetComponent<ItemBehaviour>();
                    if (item != null)
                    {
                        item.DisableChildIems();
                    }
                    this.GetComponent<BucketBehaviour>().enabled = false;
                    if (QuestManager.Main.currentQuestIndex == 8)
                    {
                        GameManager.Main.CoverTheYamWithSandQuest();
                    }
                    else if (QuestManager.Main.currentQuestIndex == 10) {
                        GameManager.Main.FillBucketWithSand();
                    }
                }
          

                
            }

        }

        if (other.CompareTag(trowelTag.ToString()) && (QuestManager.Main.currentQuestIndex == 9))
        {

            if (bucketContent == null)
            {

                ItemBehaviour item = other.GetComponent<ItemBehaviour>();
                if (item != null)
                {
                    
                    item.EnableChildIems();
                }

            }
            else
            {
                if (other.GetComponent<ItemBehaviour>().isFilled)
                {
                    ItemBehaviour item = other.GetComponent<ItemBehaviour>();
                    if (item != null)
                    {
                        item.DisableChildIems();
                    }
                    this.GetComponent<BucketBehaviour>().enabled = false;
                    GameManager.Main.AddManureToTheBucket();
                }



            }

        }

    }

    }
