using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DistanceReleaseGrabInteractable : XRGrabInteractable
{
    public float maxGrabDistance = 0.25f; // MAX DISTANCE BEFORE AUTO-RELEASE
    private IXRSelectInteractor cachedInteractor; // KEEPS TRACK OF THE INTERACTOR

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        cachedInteractor = args.interactorObject; // CACHES THE INTERACTOR
    }
    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        cachedInteractor = null;  // CLEARS CACHE ON RELEASE
    }

    // Update is called once per frame
    void Update()
    {
        if (cachedInteractor != null) // ONLY CHECK DISTANCE IF CURRENTLY GRABBED AND INTERACTOR NOT NULL
        {
            if(Vector3.Distance(cachedInteractor.transform.position, colliders[0].transform.position) > maxGrabDistance)
            {
                // IF INTERACTOR IS TOO FAR, FORCE RELEASE
                interactionManager.SelectExit(cachedInteractor, this);
            }
        }
    }

    public void DetachInteractor()
    {
        if(cachedInteractor != null)
        {
            interactionManager.SelectExit(cachedInteractor, this);
        }
    }
}
