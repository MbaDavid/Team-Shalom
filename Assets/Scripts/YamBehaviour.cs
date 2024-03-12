using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum CollisionTAG
{
    Knife,
}

public class YamBehaviour : MonoBehaviour
{
    public GameObject spawnPrefab;
    public GameObject halfYam;
    public Transform halfYamPos;
    public List<Transform> spawnPoint;
    public int numOfSpawns;
    public CollisionTAG colliderTag;

   

    private int spawnedCount = 0;
    
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

                this.GetComponent<MeshRenderer>().enabled = false;
                halfYam.SetActive(true);
                halfYam.transform.position = halfYamPos.position; 
                spawnedCount++;
            }
        }
    }
}
