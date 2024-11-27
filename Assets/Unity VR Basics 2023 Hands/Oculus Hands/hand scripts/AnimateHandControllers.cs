using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Animator))]

public class AnimateHandController : MonoBehaviour
{
    public InputActionReference gripInputActionRefernce;
    public InputActionReference triggerInputActionRefernce;

    private Animator _handAnimator;
    private float _gripValue;
    private float _triggerValue;

    private void Start()

    {
        _handAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        AnimateGrip();
        AnimateTrigger();
    }

    private void AnimateGrip()
    {
        _gripValue = gripInputActionRefernce.action.ReadValue<float>();
        _handAnimator.SetFloat("Grip", _gripValue);
    }

    private void AnimateTrigger()
    {
        _triggerValue = triggerInputActionRefernce.action.ReadValue<float>();
        _handAnimator.SetFloat("Trigger", _triggerValue);
    }
}