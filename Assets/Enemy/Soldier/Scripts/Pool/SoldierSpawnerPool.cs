using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSpawnerPool : MonoBehaviour
{
    public SoldierBullet prefBalaEnemy;

    private ObjectPool<SoldierBullet> pool;
    private static SoldierSpawnerPool _Instance;
    public static SoldierSpawnerPool Instance { get { return _Instance; } }

    void Start()
    {
        _Instance = this;
        pool = new ObjectPool<SoldierBullet>(BulletFactory, SoldierBullet.TurnOn, SoldierBullet.TurnOff, 5, true);

    }

    public SoldierBullet Spawn()
    {
        return pool.GetObject();
    }

    public SoldierBullet BulletFactory()
    {
        return Instantiate(prefBalaEnemy);
    }

    public void ReturnBullet(SoldierBullet bullet)
    {
        pool.ReturnObject(bullet);
    }
}

