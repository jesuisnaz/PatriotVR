using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIInteraction : MonoBehaviour, IShootable
{

    public UnityEvent onHitEvent;

    public void OnHit()
    {
        onHitEvent.Invoke();
    }
}
