using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ItemBehaviour : MonoBehaviour
{
    public bool isPlaced = false;
    public bool isGrabbed = false;

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    private void OnEnable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.AddListener(HandleGrabbed);
            grabInteractable.selectExited.AddListener(HandleReleased);
        }
    }

    private void OnDisable()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectEntered.RemoveListener(HandleGrabbed);
            grabInteractable.selectExited.RemoveListener(HandleReleased);
        }
    }

    private void HandleGrabbed(SelectEnterEventArgs args)
    {
        //Debug.Log(gameObject.name + " was grabbed by " + args.interactorObject.transform.gameObject.name);
        isGrabbed = true;
    }

    private void HandleReleased(SelectExitEventArgs args)
    {
        //Debug.Log(gameObject.name + " was released by " + args.interactorObject.transform.gameObject.name);
        isGrabbed = false;
    }
}
