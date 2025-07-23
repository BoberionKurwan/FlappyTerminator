using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    [SerializeField] private SpawnPoint _spawnPoint;
    [SerializeField] private int _maxBulletCount = 3;

    private Bullet bullet;

    public void Spawn()
    {
        if (_pool.CountActive + 1 <= _maxBulletCount)
        {
            bullet = _pool.Get();
            bullet.ReturnToPool += Release;
            bullet.transform.position = _spawnPoint.transform.position;
        }
    }

    private void Release(Bullet bullet)
    {
        bullet.ReturnToPool -= Release;
        _pool.Release(bullet);
    }
}