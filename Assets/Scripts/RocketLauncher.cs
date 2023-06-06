using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour, IWeapon
{
    [SerializeField] private Transform rocketCastOrigin;
    [SerializeField] private GameObject rocket;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shotFailedSound;
    [SerializeField] private AudioClip reloadSound;
    private AmmoSpawner ammoSpawner;
    public int loadedAmmoCount = 0;
    private bool isShooting = false;

    private void Awake()
    {
        ammoSpawner = FindObjectOfType<AmmoSpawner>();
    }

    public void Fire()
    {
        if (isShooting) return;
        isShooting = true;
        if (loadedAmmoCount > 0)
        {
            Instantiate(rocket, rocketCastOrigin.transform.position, rocketCastOrigin.transform.rotation);
            --loadedAmmoCount;
            if (loadedAmmoCount == 0)
            {
                ammoSpawner.RespawnAmmo();
            }
        }
        else
        {
            audioSource.PlayOneShot(shotFailedSound);
        }
        isShooting = false;
    }

    public void LoadAmmo(IAmmo ammo)
    {
        loadedAmmoCount += ammo.ammoCount;
        audioSource.PlayOneShot(reloadSound);
    }

    public int AmmoCount()
    {
        return loadedAmmoCount;
    }
}
