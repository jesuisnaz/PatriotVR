using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncherProxy : MonoBehaviour, IWeapon
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shotFailedSound;
    [SerializeField] private AudioClip reloadSound;

    private IWeapon originalRocketLauncher;
    private bool isShooting = false;
    private AmmoSpawner ammoSpawner;

    private void Awake()
    {
        originalRocketLauncher = GetComponent<RocketLauncher>();
        ammoSpawner = FindObjectOfType<AmmoSpawner>();
    }

    public void Fire()
    {
        Debug.Log("ammo count: " + originalRocketLauncher.AmmoCount());
        if (originalRocketLauncher.AmmoCount() <= 0 || isShooting)
        {
            audioSource.PlayOneShot(shotFailedSound);
            return;
        }
        isShooting = true;
        originalRocketLauncher.Fire();
        isShooting = false;
        if (originalRocketLauncher.AmmoCount() == 0)
        {
            ammoSpawner.RespawnAmmo();
        }
    }

    public void LoadAmmo(IAmmo ammo)
    {
        originalRocketLauncher.LoadAmmo(ammo);
        audioSource.PlayOneShot(reloadSound);
    }

    public int AmmoCount()
    {
        return originalRocketLauncher.AmmoCount();
    }
}
