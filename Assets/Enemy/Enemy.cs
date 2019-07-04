using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public IAdvance myCurrentStrategy;
    public IAdvance myCurrentNormal;
    public IAdvance myCurrentFollow;
    public IAdvance myCurrentBack;

    public IAdvance strategyBalaActual;

    public IController myController;

    public event Action OnGetDmg = delegate { };
    public event Action OnDeath = delegate { };
    public event Action OnLeft = delegate { };
    public event Action OnRight = delegate { };
    public event Action<bool> OnDead = delegate { }; //Agus

    public float _maxHP = 3;
    public float currentHP;
    public float fireRate, timer, distMax, distMin;

    public SoldierSpawnerPool spawnBullet;
    public Vector2 startPos;
    public Transform target;
    public Transform outputGunL;
    public Transform outputGunR;

    public bool dead;//Agus
    public float _timerCD;//Agus
    public BoxCollider2D _collider;//Agus


    public virtual void Awake()
    {
        target = GameObject.FindObjectOfType<CharacterModel>().transform;
        _collider = GetComponent<BoxCollider2D>();//Agus
        spawnBullet = GetComponent<SoldierSpawnerPool>();
        currentHP = _maxHP;
        timer = fireRate;
        startPos = transform.position;
        
    }

    public virtual void Update()
    {
        if (currentHP <=0)
        {
            Dead();
        }
        else
        {
            myController.OnUpdate();
            if (myCurrentStrategy != null)
                myCurrentStrategy.Advance();
        }
    }

    public void TakeDmg(float dmg)
    {
        currentHP -= dmg;

        OnGetDmg();

        if (currentHP < 0)
            OnDeath();
    }

    public void FlipL()
    {
        OnLeft();
    }
    public void FlipR()
    {
        OnRight();
    }

    void Dead()//Agus
    {
        _timerCD += 1 * Time.deltaTime;
        OnDead(true);
        dead = true;
        _collider.enabled = false;
        if (_timerCD > 1)
        {
            this.gameObject.SetActive(false);
        }
    }
}
