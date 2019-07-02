using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterModel : MonoBehaviour
{
    //Private
    CharacterController _characterControler;
    CharacterView _character;
    SpriteRenderer _spriteRenderer;
    Item _Item;
    bool isJumping;
    bool isCrouch;
    bool isRunning;
    bool isDead;
    float _timer;
    float _timer2;
    public CharacterWeapon _characterWeapon;


    //Public
    public Rigidbody2D rb;
    public BoxCollider2D boxIdle;
    public BoxCollider2D boxCrouch;
    public BoxCollider2D boxJump;
    public Transform transfom;
    public float speed;
    public float jumpForce;
    public int life;
    public bool inmortal;



    public Action<bool> OnJump = delegate { }; //Esto es para que se cree inicializada en vacia y no explote si lo queres ejecutar
    public Action<bool> OnRun = delegate { };
    public Action<bool> OnCrouch = delegate { };
    public Action<bool> OnShootUp = delegate { };
    public Action<bool> OnDead = delegate { };
    public Action<bool> OnInmortal = delegate { };
    public Action OnDamage = delegate { };

    private void Awake()
    {
        _characterControler = new CharacterController();
        _characterControler.SetCharacterModel(this, _character = GetComponent<CharacterView>());
        _characterWeapon = GetComponent<CharacterWeapon>();
        rb = GetComponent<Rigidbody2D>();
        transfom = GetComponent<Transform>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Start()
    {

    }


    void Update()
    {
        if (!isDead)
            _characterControler.ListenerInputs();
        Colliders();
        Inmortal();
    }

    public void Move(Vector2 Axis, bool FlipX)
    {

        float AxisY = rb.velocity.y;
        rb.velocity = new Vector2(Axis.x * speed, Axis.y + AxisY);
        if (!FlipX)
            _spriteRenderer.flipX = false;
        else if (FlipX)
            _spriteRenderer.flipX = true;
        if (rb.velocity.x != 0)
        {
            OnRun(true);
            isCrouch = false;
            OnShootUp(false);
            OnCrouch(false);
            isRunning = true;
        }
        else
        {
            OnRun(false);
            isRunning = false;
        }

        //_spriteRenderer.flipX = 
    }

    public void Jump()
    {
        {
            if (!isJumping)
            {
                isJumping = true;
                isCrouch = false;
                OnShootUp(false);
                OnCrouch(false);
                rb.AddForce(new Vector2(0, jumpForce));

                OnJump(true);
            }

        }
    }

    public void Crouch()
    {


        if (!isJumping)
        {
            isCrouch = true;
            OnShootUp(false);
            OnCrouch(true);
        }

    }

    public void Shoot(bool flipX)
    {

        _timer += 1 * Time.deltaTime;
        if (!isJumping && !isCrouch)
        {
            if (_timer > 0.25f)
            {
                _characterWeapon.Shoot(flipX);
                _timer = 0;
            }
        }
        else if (isCrouch)
        {
            if (_timer > 0.25f)
            {
                _characterWeapon.ShootCrouch(flipX);
                _timer = 0;
            }
        }

    }
    public void SeeUp()
    {


        if (!isJumping && !isRunning)
        {
            boxIdle.enabled = true;
            boxCrouch.enabled = false;
            OnShootUp(true);
        }

    }
    public void ShootUp(bool flipX)
    {

        if (!isJumping && !isRunning)
        {
            _characterWeapon.ShootUp(flipX);
        }

    }
    public void ShootFUP(bool flipX)
    {

        _timer += 1 * Time.deltaTime;
        if (!isJumping && !isCrouch)
        {
            if (_timer > 0.25f)
            {
                _characterWeapon.ShootFrontUp(flipX);
                _timer = 0;
            }
        }

    }
    public void ShootDUP(bool flipX)
    {

        _timer += 1 * Time.deltaTime;
        if (!isJumping && !isCrouch)
        {
            if (_timer > 0.25f)
            {
                _characterWeapon.ShootFrontDown(flipX);
                _timer = 0;
            }
        }

    }


    void Colliders()
    {
        if (!isJumping && !isCrouch)
        {
            boxJump.enabled = false;
            boxIdle.enabled = true;
            boxCrouch.enabled = false;
        }
        else if (isJumping && !isCrouch)
        {

            boxJump.enabled = true;
            boxIdle.enabled = false;
            boxCrouch.enabled = false;
        }
        else if (!isJumping && isCrouch)
        {
            boxJump.enabled = false;
            boxIdle.enabled = false;
            boxCrouch.enabled = true;
        }
    }

    void Life()
    {
        OnDamage();
        life--;
        if (life <= 0)
        {
            life = 0;
            boxJump.enabled = false;
            boxIdle.enabled = false;
            boxCrouch.enabled = true;
            isDead = true;
            OnDead(true);
        }
    }

    void Inmortal()
    {
        if (inmortal)
        {
            OnInmortal(true);
            _timer2 += 1 * Time.deltaTime;
            if (_timer2 > 3)
            {
                inmortal = false;
                OnInmortal(false);
                _timer2 = 0;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
            if (rb.velocity.y == 0)
                if (isJumping)
                {
                    isJumping = false;
                    OnJump(false);
                }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 8)
        {
            if (!inmortal)
                Life();
        }
    }
}
