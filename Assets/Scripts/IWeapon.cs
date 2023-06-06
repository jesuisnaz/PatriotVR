using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWeapon
{
    void Fire();
    void LoadAmmo(IAmmo ammo);
    int AmmoCount();
}
