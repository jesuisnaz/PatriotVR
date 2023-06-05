using System;
using UnityEngine;

public interface ICloneable
{
    GameObject clone(Vector3 position, Quaternion rotation);
}

