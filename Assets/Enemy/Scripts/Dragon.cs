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
    
    public event Action<float> OnGetDmg = delegate { };
    public event Action OnDeath = delegate { };
    public event Action OnLeft = delegate { };
    public event Action OnRight = delegate { };

    public float _maxHP = 3;
    public float currentHP;
    public float fireRate, timer, distMax, distMin;
    public EnemySpawnBullet spawnBullet;

    public Transform target;
    public Transform output;

    public event Action<bool> OnDead = delegate { }; //Agus
    public bool dead;//Agus
    float _timer;//Agus
    PolygonCollider2D _polygon;//Agus



    void Awake()
    {
        _polygon = GetComponent<PolygonCollider2D>();//Agus
        spawnBullet = GetComponent<EnemySpawnBullet>();
        currentHP = _maxHP;
        timer = fireRate;
        myController = new ControlEnemy(this, GetComponentInChildren<ViewEnemy>());
        myCurrentNormal = new NormalAdvance(transform);
        myCurrentFollow = new FollowAdvance(transform, target);
        myCurrentShoot = new ShootAdvance(transform, target, fireRate, timer, spawnBullet);
        OnDeath += Death;
    }

    private void Start()
    {
        //myCurrentStrategy = myCurrentNormal;
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

        OnGetDmg(currentHP / _maxHP);

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
        if(currentHP<=0)
        {
            _timer += 1 * Time.deltaTime;
            OnDead(true);
            dead = true;
            _polygon.enabled = false;
            if(_timer>1)
            {
                this.gameObject.SetActive(false);
            }
        }
    }

    private void Death()
    {
        Debug.Log("mori");
    }

    private void OnCollisionEnter2D(Collision2D collision)//Agus
    {
        if (collision.gameObject.tag == "Bullet")
            currentHP--;
    }
}
