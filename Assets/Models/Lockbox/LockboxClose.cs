using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockboxClose : MonoBehaviour
{
    Animator lockboxAnimator;
    void Start()
    {
        lockboxAnimator = this.GetComponent<Animator>();
    }

    public void CloseLockbox()
    {
        lockboxAnimator.SetBool("firearmPlaced", true);
    }
}
