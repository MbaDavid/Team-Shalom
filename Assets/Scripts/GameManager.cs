using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class GameManager : MonoBehaviour
{
    public static GameManager Main;
    public YamBehaviour bigYam;
    public TrayAction tray;
    public BucketBehaviour sandBucket;

    public TextMeshProUGUI questText;

    public Transform frontPosSpawn;

    public XROrigin xrOrigin;
    public Transform origin;

    public GameObject handTrowel;
    public GameObject Jug;
    public GameObject MainBucket;

    public GameObject plant;
    private void Awake()
    {
        if (Main == null)
        {
            Main = this;
        }
        else
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this);
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BeginQuest(1));
        //  Recenter();
    }

    public void Recenter()
    {
        xrOrigin.MoveCameraToWorldLocation(origin.position);
        xrOrigin.MatchOriginUpCameraForward(origin.up, origin.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if (QuestManager.Main.currentQuestIndex == 11)
        {
            if (handTrowel.GetComponent<ItemBehaviour>().isGrabbed == false)
            {
                DropTheTrowel();
            }
        }

        if (QuestManager.Main.currentQuestIndex == 12)
        {
            if (Jug.GetComponent<PourDetector>().pouredObject != null && Jug.GetComponent<PourDetector>().pouredObject == MainBucket)
            {
                WaterThePlantedYam();
            }
        }

        if (QuestManager.Main.currentQuestIndex == 13)
        {
            plant.transform.localScale = Vector3.Lerp(plant.transform.localScale, new Vector3(1.5f,1.5f,1.5f), Time.deltaTime * 0.125f);
        }
    }

    IEnumerator BeginQuest(float time)
    {
        yield return new WaitForSeconds(time);
        QuestManager.Main.StartQuests();
        StartCoroutine(FinishQuestIntro(3));
    }

    IEnumerator FinishQuestIntro(float time)
    {
        yield return new WaitForSeconds(time);
        QuestManager.Main.CompleteQuest(0);
    }

    public void PickUpYamQuest()
    {
        if (QuestManager.Main.currentQuestIndex == 1)
        {
            QuestManager.Main.CompleteQuest(1);
        }
    }

    public void DropTheYamQuest()
    {
        if (QuestManager.Main.currentQuestIndex == 2)
        {
            bigYam.transform.position = frontPosSpawn.position;
            bigYam.transform.rotation = Quaternion.Euler(-90, 90, 0);

            bigYam.GetComponent<Rigidbody>().velocity = Vector3.zero;
            bigYam.GetComponent<Rigidbody>().isKinematic = true;
            bigYam.GetComponent<XRGrabInteractable>().enabled = false;

            QuestManager.Main.CompleteQuest(2);
        }
    }

    public void CutuptheheadoftheyamQuest()
    {
        if (QuestManager.Main.currentQuestIndex == 3)
        {
            QuestManager.Main.CompleteQuest(3);
        }
    }

    public void PlaceHeadOfYamInTrayQuest()
    {
        if (QuestManager.Main.currentQuestIndex == 4)
        {
            QuestManager.Main.CompleteQuest(4);
            StartCoroutine(SetTrayAsideQuest(3));
        }
    }

    private IEnumerator SetTrayAsideQuest(float t)
    {
        yield return new WaitForSeconds(t);
        QuestManager.Main.CompleteQuest(5);
        StartCoroutine(MoveTowardsTheBucket(3));
    }

    private IEnumerator MoveTowardsTheBucket(float t)
    {
        yield return new WaitForSeconds(t);
        QuestManager.Main.CompleteQuest(6);
        tray.FreeAllTrayItems();
    }

    public void PlaceSliceOfYamInBucketQuest(){
             if (QuestManager.Main.currentQuestIndex == 7)
        {
            QuestManager.Main.CompleteQuest(7);
        }
        }

    public void CoverTheYamWithSandQuest()
    {
        if (QuestManager.Main.currentQuestIndex == 8)
        {
            QuestManager.Main.CompleteQuest(8);
        }
    }

    public void AddManureToTheBucket()
    {
        if (QuestManager.Main.currentQuestIndex == 9)
        {
            QuestManager.Main.CompleteQuest(9);
            sandBucket.enabled = true;
        }
    }

    public void FillBucketWithSand()
    {
        if (QuestManager.Main.currentQuestIndex == 10)
        {
            QuestManager.Main.CompleteQuest(10);
        }
    }

    public void DropTheTrowel()
    {
        if (QuestManager.Main.currentQuestIndex == 11)
        {
            QuestManager.Main.CompleteQuest(11);
        }
    }

    public void WaterThePlantedYam()
    {
        if (QuestManager.Main.currentQuestIndex == 12)
        {
            QuestManager.Main.CompleteQuest(12);
        }
    }
}
