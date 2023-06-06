using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalEnemySpawner : MonoBehaviour
{
    [Header("Shahed spawn rate")]
    public float shahedSpawnRate = 10f;
    [Header("Fighet Jet spawn chance")]
    public float fighterSpawnChance = 0.3f;

    [SerializeField] private float MIN_SPAWN_RATE = 2f;
    [SerializeField] private float SPAWN_RATE_STEP = 0.1f;

    private float spawnTimer = 0f;
    private EnemySpawner[] spawners;
    private bool spawnersEnabled = false;


    // Start is called before the first frame update
    private void Awake()
    {
        spawners = transform.GetComponentsInChildren<EnemySpawner>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (!spawnersEnabled) return;
        spawnTimer += Time.deltaTime;

        if (spawnTimer > shahedSpawnRate)
        {
            int spawnerIndex = Random.Range(0, spawners.Length);
            spawners[spawnerIndex].SpawnShahed();
            Debug.Log("Shahed spawned in spawner idx " + spawnerIndex);
            spawnTimer = 0f;
            if (Random.Range(0f, 1f) <= fighterSpawnChance)
            {
                spawnerIndex = Random.Range(0, spawners.Length);
                spawners[spawnerIndex].SpawnFighterJet();
            }
        }
    }

    internal void EnableSpawners(bool en)
    {
        spawnersEnabled = en;
        shahedSpawnRate = 10f;
        spawnTimer = 0f;
        if (!en)
        {
            foreach (EnemyHit obj in FindObjectsOfType<EnemyHit>())
            {
                obj.Explode();
            }
        }
    }

    public void ReduceSpawnRate()
    {
        if (!spawnersEnabled) return;
        if (shahedSpawnRate > MIN_SPAWN_RATE) shahedSpawnRate -= SPAWN_RATE_STEP;
        if (shahedSpawnRate < MIN_SPAWN_RATE) shahedSpawnRate = MIN_SPAWN_RATE;
    }
}
