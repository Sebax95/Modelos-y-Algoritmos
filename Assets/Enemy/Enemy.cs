using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    public IAdvance myCurrentStrategy;
    public IAdvance myCurrentNormal;

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
    
    public Vector2 startPos;
    public Transform target;
    public Transform outputGunL;
    public Transform outputGunR;

    public bool dead;//Agus
    public float _timerCD;//Agus


    public virtual void Awake()
    {
        target = GameObject.FindObjectOfType<CharacterModel>().transform;
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
        if (_timerCD > 3)
        {
            this.gameObject.SetActive(false);
        }
    }
}