using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnBullet : MonoBehaviour
{
    public EnemyBullet prefBalaEnemy;

    private ObjectPool<EnemyBullet> pool;
    private static EnemySpawnBullet _Instance;
    public static EnemySpawnBullet Instance { get { return _Instance; } }

    void Start()
    {
        _Instance = this;
        pool = new ObjectPool<EnemyBullet>(BulletFactory, EnemyBullet.TurnOn, EnemyBullet.TurnOff, 5, true);

    }

    public EnemyBullet Spawn()
    {
        return pool.GetObject();
    }

    public EnemyBullet BulletFactory()
    {
        return Instantiate(prefBalaEnemy);
    }

    public void ReturnBullet(EnemyBullet bullet)
    {
        pool.ReturnObject(bullet);
    }
}
