using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowEnemyFactory : EnemyFactory
{
    [SerializeField] private GameObject fighterEnemy;
    [SerializeField] private GameObject shahedEnemy;

    public override FighterEnemy createFighter(Vector3 spawnPoint, Transform parent)
    {
        GameObject newEnemy = fighterEnemy.GetComponent<ICloneable>().clone(spawnPoint, parent.rotation);
        newEnemy.transform.SetParent(parent);
        FighterEnemy fighter = newEnemy.GetComponent<SlowFighterEnemy>();
        Debug.Log("Slow figther spawned");
        return fighter;
    }

    public override ShahedEnemy createShahed(Vector3 spawnPoint, Transform parent)
    {
        GameObject newEnemy = shahedEnemy.GetComponent<ICloneable>().clone(spawnPoint, parent.rotation);
        newEnemy.transform.SetParent(parent);
        ShahedEnemy shahed = newEnemy.GetComponent<SlowShahedEnemy>();
        Debug.Log("Slow shaehed spawned");
        return shahed;
    }
}
