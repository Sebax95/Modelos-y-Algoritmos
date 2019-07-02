using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BestSoldier : MonoBehaviour
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
        target = GameObject.FindObjectOfType<CharacterModel>().transform;
        _collider = GetComponent<BoxCollider2D>();//Agus
        spawnBullet = GetComponent<SoldierSpawnerPool>();
        currentHP = _maxHP;
        timer = fireRate;
        startPos = transform.position;
        myController = new BSControl(this, GetComponentInChildren<BSView>());
        myCurrentNormal = new NormalSoldierAdvance(transform, startPos);
        myCurrentBack = new BackSoldierAdvance(transform, startPos);
        myCurrentFollow = new FollowSoldierAdvance(transform, target);
        myCurrentShoot = new BSShootAdvance(this, fireRate, timer);
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
        int shots = 3;
        while (shots >= 0)
        {
            var bullet = spawnBullet.Spawn();
            if (transform.position.x < target.transform.position.x)
            {
                bullet.transform.position = outputGunR.transform.position;
                if(shots == 3)
                    bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));
                else if(shots ==2)
                    bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                else
                    bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -45));

            }
            else
            {
                bullet.transform.position = outputGunL.transform.position;
                if (shots == 3)
                    bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 45));
                else if (shots == 2)
                    bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                else
                    bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 180, -45));
            }
            shots--;
        }
        shots = 3;
    }
    private void OnCollisionEnter2D(Collision2D collision)//Agus
    {
        if (collision.gameObject.tag == "Bullet")
        {
            TakeDmg(1);
        }
    }
}