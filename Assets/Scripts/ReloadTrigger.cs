using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadTrigger : MonoBehaviour
{

    [SerializeField] private RocketLauncher rocketLauncher;

    private void Awake()
    {
        rocketLauncher = GetComponentInParent<RocketLauncher>();
    }

    private void OnTriggerEnter(Collider other)
    {
        IAmmo ammo = other.gameObject.GetComponent<IAmmo>();
        if (ammo != null)
        {
            rocketLauncher.LoadAmmo(ammo);
            Destroy(other.gameObject);
        }
    }
}
