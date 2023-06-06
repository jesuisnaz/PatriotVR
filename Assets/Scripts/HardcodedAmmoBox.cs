using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardcodedAmmoBox : IAmmo
{
    [SerializeField] private int _ammoCount = 5;
    public int ammoCount { get; set ; }

    public HardcodedAmmoBox(int ammoCount)
    {
        this._ammoCount = ammoCount;
        this.ammoCount = ammoCount;
    }

    private void Start()
    {
        ammoCount = _ammoCount;
    }

    public GameObject clone(Vector3 position, Quaternion rotation)
    {
        throw new UnityException("Clone() not implemented for HardcodedAmmoBox");
    }
}
