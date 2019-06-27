using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnBullet : MonoBehaviour
{
    public EnemyBullet prefBalaEnemy;
    public Transform outputGunL;
    public Transform outputGunR;
    Dragon d;

    private ObjectPool<EnemyBullet> pool;
    private static EnemySpawnBullet _Instance;
    public static EnemySpawnBullet Instance { get { return _Instance; } }

    void Start()
    {
        _Instance = this;
        d = GetComponent<Dragon>();
        pool = new ObjectPool<EnemyBullet>(BulletFactory, EnemyBullet.TurnOn, EnemyBullet.TurnOff, 5, true);
        outputGunL = GameObject.Find("OutputL").GetComponent<Transform>();
        outputGunR = GameObject.Find("OutputR").GetComponent<Transform>();
    }

    public EnemyBullet Spawn()
    {
        var _bullet = pool.GetObject();
        if (transform.position.x < d.target.transform.position.x)
            _bullet.transform.position = outputGunR.transform.position;
        else
            _bullet.transform.position = outputGunL.transform.position;        
            
        return _bullet;
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
