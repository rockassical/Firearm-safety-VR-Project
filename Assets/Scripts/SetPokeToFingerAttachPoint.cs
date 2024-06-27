using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SetPokeToFingerAttachPoint : MonoBehaviour
{
    public Transform PokeAttachPoint;

    private XRPokeInteractor xrPokeInteractor;
    // Start is called before the first frame update
    void Start()
    {
        xrPokeInteractor = transform.parent.parent.GetComponentInChildren<XRPokeInteractor>();
    }

    private void SetPokeAttachPoint()
    {
        if (PokeAttachPoint == null)
        {
            Debug.Log("Poke Attach Point is null"); return;
        }
        if(xrPokeInteractor == null)
        {
            Debug.Log("XR Poke Interactor is null"); return;
        }

        xrPokeInteractor.attachTransform = PokeAttachPoint;
    }

}
