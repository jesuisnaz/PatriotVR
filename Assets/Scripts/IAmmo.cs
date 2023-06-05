using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAmmo : ICloneable
{
    public int ammoCount { get; set; }
}
