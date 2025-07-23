using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner<Enemy>
{
    [SerializeField] private List<SpawnPoint> _spawnPoints;

    private Coroutine _spawnCoroutine;
    private List<SpawnPoint> _temporarySpawnPoints;

    private void Start()
    {
        _spawnCoroutine = StartCoroutine(SpawnRoutine());
        _temporarySpawnPoints = new List<SpawnPoint>(_spawnPoints);
    }

    private IEnumerator SpawnRoutine()
    {
        float minRandomWaitTime = 1f;
        float maxRandomWaitTime = 3f;

        WaitForSeconds spawnInterval = new WaitForSeconds(Random.Range(minRandomWaitTime, maxRandomWaitTime));

        while (enabled)
        {
            yield return spawnInterval;

            if (_temporarySpawnPoints.Count != 0)
            {
                Spawn();
            }
            else
            {
                _temporarySpawnPoints = new List<SpawnPoint>(_spawnPoints);
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        int randomIndex = Random.Range(0, _temporarySpawnPoints.Count);
        SpawnPoint spawnPoint = _temporarySpawnPoints[randomIndex];
        _temporarySpawnPoints.RemoveAt(randomIndex);

        Enemy enemy = _pool.Get();
        enemy.ReturnToPool += Release;

        enemy.transform.position = spawnPoint.transform.position;
    }

    private void Release(Enemy enemy)
    {
        enemy.ReturnToPool -= Release;
        _pool.Release(enemy);
    }

#if UNITY_EDITOR
    [ContextMenu("Refresh Child Array")]
    private void RefreshChildArray()
    {
        _spawnPoints.Clear();

        foreach (Transform child in transform)
        {
            if (child.TryGetComponent(out SpawnPoint spawnPoint))
            {
                _spawnPoints.Add(spawnPoint);
            }
        }
    }
#endif
}
