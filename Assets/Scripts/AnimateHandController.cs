using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]
public class AnimateHandController : MonoBehaviour
{
    public InputActionReference gripInputActionRef;
    public InputActionReference triggerInputActionRef;

    private Animator _handAnimator;
    private float _gripValue;
    private float _triggerValue;
    void Start()
    {
        _handAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimateGrip();
        AnimateTrigger();
    }

    private void AnimateGrip()
    {
        _gripValue = gripInputActionRef.action.ReadValue<float>();
        _handAnimator.SetFloat("Grip", _gripValue);
    }
    private void AnimateTrigger()
    {
        _triggerValue = triggerInputActionRef.action.ReadValue<float>();
        _handAnimator.SetFloat("Trigger", _triggerValue);
    }
}
