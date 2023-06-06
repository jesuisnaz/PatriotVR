using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtraShotWeaponDecorator : WeaponDecorator
{
    public override void Fire()
    {
        base.Fire();
        if (AmmoCount() <= 0) return;
        // 25% chance to shoot 3 rockets at once
        if (UnityEngine.Random.Range(0, 4) == 1)
        {
            Debug.Log("Shooting multiple times!");
            base.LoadAmmo(new HardcodedAmmoBox(3));
            StartCoroutine(FireThreeAtOnce());
        }
    }

    private IEnumerator FireThreeAtOnce()
    {
        yield return new WaitForSeconds(0.15f);
        base.Fire();
        yield return new WaitForSeconds(0.15f);
        base.Fire();
        yield return new WaitForSeconds(0.15f);
        base.Fire();
    }

    public override void LoadAmmo(IAmmo ammo)
    {
        base.LoadAmmo(ammo);
    }
}
