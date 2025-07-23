using UnityEngine;

public class BulletSpawner : Spawner<Bullet>
{
    [SerializeField] private SpawnPoint _spawnPoint;
    [SerializeField] private int _maxBulletCount = 3;

    public void Spawn()
    {
        if (Pool.CountActive + 1 <= _maxBulletCount)
        {
            Bullet bullet = Pool.Get();
            bullet.ReturnToPool += Release;
            bullet.transform.position = _spawnPoint.transform.position;
        }
    }

    private void Release(Bullet bullet)
    {
        bullet.ReturnToPool -= Release;
        Pool.Release(bullet);
    }
}