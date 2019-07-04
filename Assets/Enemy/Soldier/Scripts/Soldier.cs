using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Soldier : Enemy
{
    public override void Awake()
    {
        base.Awake();
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
    
    private void OnCollisionEnter2D(Collision2D collision)//Agus
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDmg(1);
        }
    }
}
