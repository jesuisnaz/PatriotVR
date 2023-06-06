using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowShahedEnemy : ShahedEnemy, ICloneable
{

    public float slowFactor = 2f;

    internal override Vector3 MovePerTime(GameObject shahed)
    {
        return base.MovePerTime(shahed) / slowFactor;
    }

    public new GameObject clone(Vector3 position, Quaternion rotation)
    {
        return Instantiate(this.gameObject, position, rotation);
    }
}
