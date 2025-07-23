using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BulletSpawner))]
public class Shooter : MonoBehaviour
{
    [SerializeField] private SpawnPoint _spawnPoint;

    private BulletSpawner _bulletSpawner;

    private Coroutine _coroutine;

    private void Awake()
    {
        _bulletSpawner = GetComponent<BulletSpawner>();
    }

    private void Start()
    {
        _coroutine = StartCoroutine(ShootRoutine());
    }

    private IEnumerator ShootRoutine()
    {
        float minInterval = 1f;
        float maxInterval = 3f;

        WaitForSeconds shootInterval = new WaitForSeconds(UnityEngine.Random.Range(minInterval, maxInterval));

        while (enabled)
        {
            yield return shootInterval;

            _bulletSpawner.Spawn();
        }
    }
}
