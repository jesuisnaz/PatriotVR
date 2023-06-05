using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LauncherAmmoBox : MonoBehaviour, IAmmo
{
    [SerializeField] private int _ammoCount = 5;
    public int ammoCount { get; set ; }

    private void Start()
    {
        ammoCount = _ammoCount;
    }

    public GameObject clone(Vector3 position, Quaternion rotation)
    {
        return Instantiate(this.gameObject, position, rotation);
    }
}
