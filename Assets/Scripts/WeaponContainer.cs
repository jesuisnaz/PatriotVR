using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponContainer : MonoBehaviour
{
    [SerializeField] private GameObject weaponHolder;
    [SerializeField] private GameObject extraShotDecoratorObject;
    [SerializeField] private GameObject extraAmmoDecoratorObject;
    [SerializeField] private TMP_Text ammoCountText;

    private IWeapon weapon;
    private Boolean hasExtraShot = false;
    private Boolean hasExtraAmmo = false;

    private void Awake()
    {
        weapon = weaponHolder.GetComponent<RocketLauncherProxy>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    public void Fire()
    {
        weapon.Fire();
        ammoCountText.text = weapon.AmmoCount() + "";
    }

    public void LoadAmmo(IAmmo ammo)
    {
        weapon.LoadAmmo(ammo);
        ammoCountText.text = weapon.AmmoCount() + "";
    }


    public void AddExtraAmmoFeature()
    {
        hasExtraAmmo = true;
        GameObject go = Instantiate(extraAmmoDecoratorObject, Vector3.zero, Quaternion.identity);
        WeaponDecorator newDecorator = go.GetComponent<WeaponDecorator>();
        newDecorator.SetWrappee(weapon);
        this.weapon = newDecorator;
    }

    internal void AddExtraShotFeature()
    {
        hasExtraShot = true;
        GameObject go = Instantiate(extraShotDecoratorObject, Vector3.zero, Quaternion.identity);
        WeaponDecorator newDecorator = go.GetComponent<WeaponDecorator>();
        newDecorator.SetWrappee(weapon);
        this.weapon = newDecorator;
    }

    internal bool HasExtraAmmo()
    {
        return hasExtraAmmo;
    }

    internal bool HasExtraShot()
    {
        return hasExtraShot;
    }
}
