using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SlowFighterEnemy : FighterEnemy, ICloneable
{

    public float slowFactor = 2f;

    internal override Vector3 MovePerTime()
    {
        return base.MovePerTime() / slowFactor;
    }


    public new GameObject clone(Vector3 position, Quaternion rotation)
    {
        return Instantiate(this.gameObject, position, Quaternion.identity);
    }
}
