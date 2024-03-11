using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructorBehaviour : MonoBehaviour
{
    public Transform player; 
    public float detectionRange = 5f;
    public float rotationSpeed = 5f;
    private Quaternion originalRotation;
    private bool playerDetected = false;
    private float lookTime = 3f; 
    private float timer = 0f;

    void Start()
    {
        
        originalRotation = transform.rotation;
    }

    void Update()
    {
       
        if (Vector3.Distance(transform.position, player.position) < detectionRange)
        {
          
            playerDetected = true;
            timer = lookTime; // Reset the timer whenever the player is detected
        }
        else
        {
           
            playerDetected = false;
        }

        if (playerDetected)
        {
            // Rotate towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        }
        else if (timer <= 0)
        {
            // Return to original rotation if the player is not detected and timer is up
            transform.rotation = Quaternion.Slerp(transform.rotation, originalRotation, Time.deltaTime * rotationSpeed);
        }

        // Update the timer
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }
}
