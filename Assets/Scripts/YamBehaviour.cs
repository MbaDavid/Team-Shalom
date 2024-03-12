using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CollisionTAG
{
    Knife,
    YamSlice
}

public class YamBehaviour : MonoBehaviour
{
    public GameObject spawnPrefab;
    public GameObject spawnSmallSlice;
    public GameObject halfYam;
    public Transform halfYamPos;
    public List<Transform> spawnPoint;
    public int numOfSpawns;
    public CollisionTAG colliderTag;

   

    private int spawnedCount = 0;
    List<GameObject> sliceYam = new List<GameObject>();
    List<GameObject> smallSliceYam = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnedCount >= numOfSpawns + 3)
        {
            GameManager.Main.CutuptheheadoftheyamQuest();
        }
    }

    int i = 0;

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag(colliderTag.ToString()))
        {
            if (QuestManager.Main.currentQuestIndex != 3)
                return;


            if (spawnedCount < numOfSpawns)
            {
    
               GameObject go = Instantiate(spawnPrefab, spawnPoint[spawnedCount].transform.position,  spawnPrefab.transform.rotation);
                go.SetActive(true);
                sliceYam.Add(go);

                this.GetComponent<MeshRenderer>().enabled = false;
                halfYam.SetActive(true);
                halfYam.transform.position = halfYamPos.position;
                halfYam.GetComponent<MeshRenderer>().enabled = true;
                spawnedCount++;
            }

            if (spawnedCount >= 3 && i < 3)
            {
                GameObject go2 = Instantiate(spawnSmallSlice, spawnPoint[i].transform.position, spawnSmallSlice.transform.rotation);

                go2.SetActive(true);
                smallSliceYam.Add(go2);


                halfYam.GetComponent<MeshRenderer>().enabled = false;
          
                sliceYam[i].SetActive(false);
                i++;
                spawnedCount++;
            }
        }
    }
}
