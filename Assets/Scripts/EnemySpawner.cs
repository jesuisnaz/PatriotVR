using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Size of the spawner area")]
    public Vector3 spawnerSize;

    [SerializeField] private EnemyFactory defaultEnemyFactory;
    [SerializeField] private EnemyFactory slowEnemyFactory;

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

        GetFactory().createShahed(spawnPoint, this.transform);
    }

    internal void SpawnFighterJet()
    {
        Vector3 spawnPoint = transform.position + new Vector3(
            UnityEngine.Random.Range(-spawnerSize.x / 2, spawnerSize.x / 2),
            UnityEngine.Random.Range(-spawnerSize.y / 2, spawnerSize.y / 2),
            UnityEngine.Random.Range(-spawnerSize.z / 2, spawnerSize.z / 2)
        );
        GetFactory().createFighter(spawnPoint, this.transform);
    }

    private EnemyFactory GetFactory()
    {
        int range = UnityEngine.Random.Range(0, 2);
        if (range == 1) return slowEnemyFactory;
        return defaultEnemyFactory;
    }
}
