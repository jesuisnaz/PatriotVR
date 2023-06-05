using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShahedSpawner : MonoBehaviour
{
    [Header("Size of the spawner area")]
    public Vector3 spawnerSize;

    [Header("Enemy prototype")]
    [SerializeField] private GameObject enemyPrototype;

    private void Start()
    {
        if (enemyPrototype.GetComponent<ICloneable>() == null)
        {
            Debug.LogError("enemy prototype is not ICloneable!");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(0, 1, 0, 0.5f);
        Gizmos.DrawCube(transform.position, spawnerSize);
    }

    public void SpawnShahed()
    {
        Vector3 spawnPoint = transform.position + new Vector3(
            UnityEngine.Random.Range(-spawnerSize.x / 2, spawnerSize.x / 2),
            UnityEngine.Random.Range(-spawnerSize.y / 2, spawnerSize.y / 2),
            UnityEngine.Random.Range(-spawnerSize.z / 2, spawnerSize.z / 2)
        );
        GameObject newEnemy = enemyPrototype.GetComponent<ICloneable>().clone(spawnPoint, transform.rotation);
        newEnemy.transform.SetParent(this.transform);
    }
}
