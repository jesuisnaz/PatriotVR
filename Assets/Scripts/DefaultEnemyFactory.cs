using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemyFactory : EnemyFactory
{
    [SerializeField] private GameObject fighterEnemy;
    [SerializeField] private GameObject shahedEnemy;

    public override FighterEnemy createFighter(Vector3 spawnPoint, Transform parent)
    {
        GameObject newEnemy = fighterEnemy.GetComponent<ICloneable>().clone(spawnPoint, parent.rotation);
        newEnemy.transform.SetParent(parent);
        return newEnemy.GetComponent<FighterEnemy>();
    }

    public override ShahedEnemy createShahed(Vector3 spawnPoint, Transform parent)
    {
        GameObject newEnemy = shahedEnemy.GetComponent<ICloneable>().clone(spawnPoint, parent.rotation);
        newEnemy.transform.SetParent(parent);
        return newEnemy.GetComponent<ShahedEnemy>();
    }
}
