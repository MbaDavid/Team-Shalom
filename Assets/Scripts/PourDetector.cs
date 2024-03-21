using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class PourDetector : MonoBehaviour
{
    public float pourThreshold = 45;
    [SerializeField] private Transform target;   
    
    private bool isPouring = false;

    [SerializeField] private GameObject pourEffect;
    public GameObject pouredObject;
    public LayerMask pourLayermask;
    // Update is called once per frame
    void Update()
    {
       
        bool pourCheck = CalculatePourAngle() > pourThreshold;

        if (isPouring)
        {
            pouredObject = GetPourPoint();
        }
        else
        {
            pouredObject = null;
        }

        if (pourCheck != isPouring )
        {
            isPouring = pourCheck;
            if (isPouring)
            {
                StartPour();

            }
            else
            {
                EndPour();
            }
        }
    }

    private void StartPour()
    {
        pourEffect.SetActive(true);
       // pouredObject = GetPourPoint();
    }

    private void EndPour()
    {
        pourEffect.SetActive(false);
        pouredObject = null;
    }

    private GameObject GetPourPoint()
    {
        Ray ray = new Ray(target.position, -target.forward);

        Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, pourLayermask);
        //Debug.DrawLine(target.position,  -target.forward * 1000, Color.red);
        if (hit.collider == null)
            return null;

        if (hit.collider.CompareTag(CollisionTAG.MainBucket.ToString())) {
            //Debug.Log(hit.collider.name);
            return hit.collider.gameObject;
        }

        return null;
 
    }

    private float CalculatePourAngle()
    {
        
        return target.forward.y * Mathf.Rad2Deg;
    }
}
