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
    // Update is called once per frame
    void Update()
    {
       
        bool pourCheck = CalculatePourAngle() > pourThreshold;

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
        pouredObject = GetPourPoint();
    }

    private void EndPour()
    {
        pourEffect.SetActive(false);
        pouredObject = null;
    }

    private GameObject GetPourPoint()
    {
        Ray ray = new Ray(target.position, -target.up);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, Mathf.Infinity);

        return hit.collider.gameObject;
    }

    private float CalculatePourAngle()
    {
        
        return target.forward.y * Mathf.Rad2Deg;
    }
}
