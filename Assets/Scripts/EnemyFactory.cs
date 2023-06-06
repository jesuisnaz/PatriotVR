using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyFactory : MonoBehaviour
{
    public abstract FighterEnemy createFighter(Vector3 spawnPoint, Transform parent);
    public abstract ShahedEnemy createShahed(Vector3 spawnPoint, Transform parent);
}
