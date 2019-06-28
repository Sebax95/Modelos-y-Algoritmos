using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Soldier : MonoBehaviour
{

    public IAdvance myCurrentStrategy;
    public IAdvance myCurrentNormal;
    public IAdvance myCurrentFollow;
    public IAdvance myCurrentShoot;
    public IAdvance myCurrentBack;

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
    float _timer;//Agus
    BoxCollider2D _collider;//Agus



    void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();//Agus
        spawnBullet = GetComponent<SoldierSpawnerPool>();
        currentHP = _maxHP;
        timer = fireRate;
        startPos = transform.position;
        myController = new ControlSoldier(this, GetComponentInChildren<ViewSoldier>());
        myCurrentNormal = new NormalSoldierAdvance(transform, startPos);
        myCurrentBack = new BackSoldierAdvance(transform, startPos);
        myCurrentFollow = new FollowSoldierAdvance(transform, target);
        myCurrentShoot = new ShootSoldierAdvance(this, fireRate, timer);
    }

    private void Start()
    {

    }

    void Update()
    {
        Dead();
        myController.OnUpdate();
        if (myCurrentStrategy != null)
            myCurrentStrategy.Advance();
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
        if (currentHP <= 0)
        {
            _timer += 1 * Time.deltaTime;
            OnDead(true);
            dead = true;
            _collider.enabled = false;
            if (_timer > 1)
            {
                this.gameObject.SetActive(false);
            }
        }
    }
    public void ShootBullet()
    {
        var bullet = spawnBullet.Spawn();
        if (transform.position.x < target.transform.position.x)
        {
            bullet.transform.position = outputGunR.transform.position;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        else
        {
            bullet.transform.position = outputGunL.transform.position;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)//Agus
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDmg(1);
        }
    }
}
