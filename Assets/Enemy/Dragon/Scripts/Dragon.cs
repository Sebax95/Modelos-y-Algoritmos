using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Dragon : MonoBehaviour
{
    public IAdvance myCurrentStrategy;
    public IAdvance myCurrentNormal;
    public IAdvance myCurrentFollow;
    public IAdvance myCurrentShoot;
    
    public IController myController;
    
    public event Action OnGetDmg = delegate { };
    public event Action OnDeath = delegate { };
    public event Action OnLeft = delegate { };
    public event Action OnRight = delegate { };
    public event Action<bool> OnDead = delegate { }; //Agus

    public float _maxHP = 3;
    public float currentHP;
    public float fireRate, timer, distMax, distMin;

    public EnemySpawnBullet spawnBullet;

    public Transform target;
    public Transform outputGunR;
    public Transform outputGunL;

    public bool dead;//Agus
    float _timer;//Agus
    PolygonCollider2D _polygon;//Agus



    void Awake()
    {
        _polygon = GetComponent<PolygonCollider2D>();//Agus
        spawnBullet = GetComponent<EnemySpawnBullet>();
        currentHP = _maxHP;
        timer = fireRate;
        outputGunL = GameObject.Find("OutputL").GetComponent<Transform>();
        outputGunR = GameObject.Find("OutputR").GetComponent<Transform>();
        myController = new ControlEnemy(this, GetComponentInChildren<ViewEnemy>());
        myCurrentNormal = new NormalAdvance(transform);
        myCurrentFollow = new FollowAdvance(transform, target);
        myCurrentShoot = new ShootAdvance(this, fireRate, timer);
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

    public void ShootBullet()
    {
        var bullet = spawnBullet.Spawn();
        if (transform.position.x < target.transform.position.x)
        {
            bullet.transform.position = outputGunL.transform.position;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -Vector3.Angle(transform.position, target.position) - 5));

        }
        else
        {
            bullet.transform.position = outputGunR.transform.position;
            bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 180, -Vector3.Angle(transform.position, target.position) - 5));
        }
    }

    void Dead()//Agus
    {
        if (currentHP <= 0)
        {
            _timer += 1 * Time.deltaTime;
            OnDead(true);
            dead = true;
            _polygon.enabled = false;
            if (_timer > 1)
            {
                this.gameObject.SetActive(false);
            }
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
