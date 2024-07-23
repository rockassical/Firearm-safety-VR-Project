using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DoorControllerBasedOnMovement : MonoBehaviour
{
    public GameObject doorHandle;
    public DistanceReleaseGrabInteractable grabInteractable;
    public float movementThreshold = 0.25f; //Amount Handle must move to activate animation

    private Animator doorAnimator;
    private Vector3 startPosition;
    private bool handleGrabbed = false;
    private bool doorOpened = false;

    private void Awake()
    {
        if (!doorHandle)
        {
            Debug.LogError("Door Handle Not Assigned in Inspector.");
            enabled = false;
            return;
        }
        doorAnimator = GetComponent<Animator>();
        if (!doorAnimator)
        {
            Debug.LogError("Door Controller is Missing");
            enabled = false;
            return;
        }
        if (!grabInteractable)
        {
            Debug.LogError("Door Controller missing grab interactable");
            enabled = false;
            return;
        }
        grabInteractable.selectEntered.AddListener(HandleGrabbed);
        grabInteractable.selectExited.AddListener(HandleReleased);
    }
    private void OnDestroy()
    {
        grabInteractable.selectEntered.RemoveListener(HandleGrabbed);
        grabInteractable.selectExited.RemoveListener(HandleReleased);
    }
    private void HandleGrabbed(SelectEnterEventArgs arg)
    {
        startPosition = doorHandle.transform.position;
        handleGrabbed = true;
    }
    private void HandleReleased(SelectExitEventArgs arg)
    {
        handleGrabbed = false;
    }

    private void Update()
    {
        if (handleGrabbed)
        {
            float distanceMoved = Vector3.Distance(doorHandle.transform.position, startPosition);
            if (distanceMoved > movementThreshold && !doorOpened)
            {
                grabInteractable.DetachInteractor();
                //OPEN DOOR
                doorAnimator.SetBool("isOpen", true);
                doorOpened = true;
            }
            else if (distanceMoved > movementThreshold && doorOpened)
            {
                grabInteractable.DetachInteractor();
                //CLOSE DOOR
                doorAnimator.SetBool("isOpen", false);
                doorOpened = false;
            }
        }
    }
}
