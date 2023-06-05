using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    [SerializeField] private Transform rocketCastOrigin;
    [SerializeField] private GameObject rocket;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip shotFailedSound;
    [SerializeField] private AudioClip reloadSound;
    [SerializeField] private AmmoSpawner ammoSpawner;
    public int loadedAmmoCount = 0;

    private void Awake()
    {
        ammoSpawner = FindObjectOfType<AmmoSpawner>();
    }

    public void Fire()
    {
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
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Fire();
        }
    }

    internal void LoadAmmo(IAmmo ammo)
    {
        loadedAmmoCount += ammo.ammoCount;
        audioSource.PlayOneShot(reloadSound);
    }
}
