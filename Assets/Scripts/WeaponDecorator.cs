using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDecorator : MonoBehaviour, IWeapon
{
    private IWeapon wrappee;

    public void SetWrappee(IWeapon wrappee)
    {
        this.wrappee = wrappee;
    }

    public virtual void Fire()
    {
        wrappee.Fire();
    }

    public virtual void LoadAmmo(IAmmo ammo)
    {
        wrappee.LoadAmmo(ammo);
    }

    public int AmmoCount()
    {
        return this.wrappee.AmmoCount();
    }
}
