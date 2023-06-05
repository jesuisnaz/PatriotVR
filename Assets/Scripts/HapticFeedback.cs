using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HapticFeedback : MonoBehaviour
{
    [SerializeField] XRGrabInteractable interactable;

    private void OnEnable()
    {
        interactable.activated.AddListener(SendHapticFeedback);
    }

    private void OnDisable()
    {
        interactable.activated.RemoveListener(SendHapticFeedback);
    }

    private void SendHapticFeedback(ActivateEventArgs arg0)
    {
        arg0.interactorObject.transform.GetComponent<XRBaseController>().SendHapticImpulse(1f, .2f);
    }
}
