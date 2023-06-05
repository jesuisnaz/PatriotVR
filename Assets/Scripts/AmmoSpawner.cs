using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawner : MonoBehaviour
{
    [SerializeField] private GameObject ammoPrototype;
    [SerializeField] private Vector3 spawnPoint;
    [SerializeField] private Quaternion spawnRotation;
    private GameObject currentInstance;

    private void Awake()
    {
        if (ammoPrototype.GetComponent<IAmmo>() == null)
        {
            Debug.LogError("Ammo prototype does not implement IAmmo!");
        }
    }

    private void Start()
    {
        RespawnAmmo();
    }

    public void RespawnAmmo()
    {
        if (currentInstance != null)
        {
            Destroy(currentInstance);
        }
        currentInstance = ammoPrototype.GetComponent<IAmmo>().clone(spawnPoint, spawnRotation);
    }

}
