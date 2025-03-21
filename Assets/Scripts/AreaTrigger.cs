using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AreaTrigger : MonoBehaviour
{
    public UnityEvent triggerEvent;
    // Start is called before the first frame update
    void Start()
    {
        if (triggerEvent == null)
        {
            triggerEvent = new UnityEvent();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            triggerEvent.Invoke();
        }
    }
}
