using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BestSoldier : Enemy
{
    public SoldierSpawnerPool spawnBullet;

    public IAdvance myCurrentFollow;
    public IAdvance myCurrentBack;

    public BoxCollider2D _collider;//Agus

    public event Action OnShoot = delegate { };
    public event Action OnWalk = delegate { };

    public override void Awake()
    {
        base.Awake();
        _collider = GetComponent<BoxCollider2D>();//Agus
        spawnBullet = GetComponent<SoldierSpawnerPool>();
        myController = new BSControl(this, GetComponentInChildren<BSView>());
        myCurrentNormal = new NormalSoldierAdvance(transform, startPos);
        myCurrentBack = new BackSoldierAdvance(transform, startPos);
        myCurrentFollow = new FollowSoldierAdvance(transform, target);
        strategyBalaActual = new TripleBalaAdvance(spawnBullet, target, outputGunR, outputGunL, transform, timer, fireRate);
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