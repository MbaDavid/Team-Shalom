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

    public TextMeshProUGUI questText;

    public Transform frontPosSpawn;

    public XROrigin xrOrigin;
    public Transform origin;

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
       StartCoroutine( BeginQuest(1));
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
            bigYam.GetComponent<Rigidbody>().isKinematic =true;
            bigYam.GetComponent<XRGrabInteractable>().enabled =false;

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
}
