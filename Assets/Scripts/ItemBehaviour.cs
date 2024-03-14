using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ItemBehaviour : MonoBehaviour
{
    [HideInInspector] public bool isPlaced = false;
    [HideInInspector] public bool isGrabbed = false;
    public bool isFilled = false;

    public List<GameObject> childItems = new List<GameObject>();

    private XRGrabInteractable grabInteractable;

    private void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    public void EnableChildIems()
    {
        if (childItems == null || childItems.Count == 0) return;
        for (int i = 0; i < childItems.Count; i++)
        {
            childItems[i].SetActive(true);
        }
        isFilled = true;
    }

    public void DisableChildIems()
    {
        if (childItems == null || childItems.Count == 0) return;
        for (int i = 0; i < childItems.Count; i++)
        {
            childItems[i].SetActive(false);
        }
        isFilled = false;
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
