using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraAmmoWeaponDecorator : WeaponDecorator
{
    public override void Fire()
    {
        base.Fire();
    }

    public override void LoadAmmo(IAmmo ammo)
    {
        base.LoadAmmo(ammo);
        // 25% chance to load ammo twice
        if (UnityEngine.Random.Range(0, 4) == 1)
        {
            Debug.Log("loading ammo twice!");
            base.LoadAmmo(ammo);
        }
    }
}
