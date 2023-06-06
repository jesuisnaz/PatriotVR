using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour, IWeapon
{
    [SerializeField] private Transform rocketCastOrigin;
    [SerializeField] private GameObject rocket;
    public int loadedAmmoCount = 0;

    public void Fire()
    {
        Instantiate(rocket, rocketCastOrigin.transform.position, rocketCastOrigin.transform.rotation);
        --loadedAmmoCount;
    }

    public void LoadAmmo(IAmmo ammo)
    {
        loadedAmmoCount += ammo.ammoCount;
    }

    public int AmmoCount()
    {
        return loadedAmmoCount;
    }
}
