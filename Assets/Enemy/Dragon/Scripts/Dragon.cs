using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragon : Enemy
{
    public IAdvance myCurrentFollow;
  
    public EnemySpawnBullet spawnBullet;

    PolygonCollider2D _polygon;//Agus



    public override void Awake()
    {
        base.Awake();
        spawnBullet = GetComponent<EnemySpawnBullet>();
        outputGunR = GameObject.Find("OutputR").GetComponent<Transform>();
        outputGunL = GameObject.Find("OutputL").GetComponent<Transform>();
        myController = new ControlEnemy(this, GetComponentInChildren<ViewEnemy>());
        myCurrentNormal = new NormalAdvance(transform);
        myCurrentFollow = new FollowAdvance(transform, target);
        strategyBalaActual = new ShootAdvance(spawnBullet, target, outputGunR, outputGunL, transform, timer, fireRate);
    }

    public override void Update()
    {
        base.Update();
    }

    private void OnCollisionEnter2D(Collision2D collision)//Agus
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDmg(1);
        }
    }
}
