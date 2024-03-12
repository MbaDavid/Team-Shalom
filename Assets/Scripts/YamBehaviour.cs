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
        if (spawnedCount >= numOfSpawns)
        {
            GameManager.Main.CutuptheheadoftheyamQuest();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag(colliderTag.ToString()))
        {
       
            if (spawnedCount < numOfSpawns)
            {
                int i = spawnedCount > spawnPoint.Count ? spawnPoint.Count : spawnedCount;
                Instantiate(spawnPrefab, spawnPoint[i].transform.position, Quaternion.identity);
                spawnedCount++;
            }
        }
    }
}
