using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalShahedSpawner : MonoBehaviour
{
    [Header("Spawn rate")]
    public float spawnRate = 10f;

    [SerializeField] private float MIN_SPAWN_RATE = 2f;
    [SerializeField] private float SPAWN_RATE_STEP = 0.1f;

    private float spawnTimer = 0f;
    private ShahedSpawner[] spawners;
    private bool spawnersEnabled = false;


    // Start is called before the first frame update
    private void Awake()
    {
        spawners = transform.GetComponentsInChildren<ShahedSpawner>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!spawnersEnabled) return;
        spawnTimer += Time.deltaTime;

        if (spawnTimer > spawnRate)
        {
            int spawnerIndex = Random.Range(0, spawners.Length);
            spawners[spawnerIndex].SpawnShahed();
            Debug.Log("Shahed spawned in spawner idx " + spawnerIndex);
            spawnTimer = 0f;
        }
    }

    internal void EnableSpawners(bool en)
    {
        spawnersEnabled = en;
        spawnRate = 10f;
        spawnTimer = 0f;
        if (!en)
        {
            foreach (ShahedHit obj in FindObjectsOfType<ShahedHit>())
            {
                obj.Explode();
            }
        }
    }

    public void ReduceSpawnRate()
    {
        if (!spawnersEnabled) return;
        if (spawnRate > MIN_SPAWN_RATE) spawnRate -= SPAWN_RATE_STEP;
        if (spawnRate < MIN_SPAWN_RATE) spawnRate = MIN_SPAWN_RATE;
    }
}
