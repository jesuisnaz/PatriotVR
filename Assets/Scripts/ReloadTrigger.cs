using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadTrigger : MonoBehaviour
{

    [SerializeField] private WeaponContainer weaponContainer;

    private void Awake()
    {
        weaponContainer = GetComponentInParent<WeaponContainer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        IAmmo ammo = other.gameObject.GetComponent<IAmmo>();
        if (ammo != null)
        {
            weaponContainer.LoadAmmo(ammo);
            Destroy(other.gameObject);
        }
    }
}
