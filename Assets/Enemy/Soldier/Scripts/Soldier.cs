using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Soldier : Enemy
{
    public SoldierSpawnerPool spawnBullet;
    public IAdvance myCurrentFollow;
    public IAdvance myCurrentBack;

    public event Action OnShoot = delegate { };
    public event Action OnWalk = delegate { };


    public override void Awake()
    {
        base.Awake();
        spawnBullet = GetComponent<SoldierSpawnerPool>();
        myController = new ControlSoldier(this, GetComponentInChildren<ViewSoldier>());
        myCurrentNormal = new NormalSoldierAdvance(transform, startPos);
        myCurrentBack = new BackSoldierAdvance(transform, startPos);
        myCurrentFollow = new FollowSoldierAdvance(transform, target);
        strategyBalaActual = new NormalBalaAdvance(spawnBullet, target, outputGunR, outputGunL, transform, timer, fireRate);
    }

    public override void Update()
    {
        base.Update();
    }

    public void Shoot()
    {
        OnShoot();
    }
    public void Walk()
    {
        OnWalk();
    }

    private void OnCollisionEnter2D(Collision2D collision)//Agus
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDmg(1);
        }
    }
}
