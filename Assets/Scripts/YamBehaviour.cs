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
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(colliderTag.ToString()))
        {
            Debug.Log("Action");
            Instantiate(spawnPrefab, spawnPoint[spawnedCount].transform.position, Quaternion.identity);
        }
    }
}
