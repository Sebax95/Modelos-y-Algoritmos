using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterModel : MonoBehaviour, IObservable
{
    //Private
    CharacterWeapon _characterWeapon;
    CharacterController _characterControler;
    CharacterView _character;
    SpriteRenderer _spriteRenderer;
    Item _Item;
    bool isJumping;
    bool isCrouch;
    bool isRunning;
    bool isDead;
    bool isSeeUp;
    float _timer;
    float _timer2;


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

    private List<IObserver> _allObservers = new List<IObserver>();

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
         EventsManager.SubscribeToEvent(EventType.GP_MoreHp, MoreHP);
        EventsManager.SubscribeToEvent(EventType.GP_MoreSpeed,MoreSpeed);
        EventsManager.SubscribeToEvent(EventType.GP_Inmortal, Inmortal);
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
            isCrouch = false;
            isRunning = true;
            isSeeUp = false;
            OnRun(true);
            OnShootUp(false);
            OnCrouch(false);
        }
        else
        {
            isRunning = false;
            OnRun(false);
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
                isSeeUp = false;
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
            isSeeUp = false;
            OnShootUp(false);
            OnCrouch(true);
        }

    }

    public void SeeUp()
    {
        if (!isJumping)
        {
            isSeeUp = true;
            isCrouch = false;
            OnShootUp(true);
            OnCrouch(false);
        }
    }

    public void Shoot(bool flipX)
    {
        _timer += 1 * Time.deltaTime;
        if (!isJumping && !isCrouch && !isSeeUp )
        {
            if (_timer > 0.25f)
            {
                _characterWeapon.Shoot(flipX);
                _timer = 0;
            }
            if (flipX)
            {
                for (int i = _allObservers.Count - 1; i >= 0; i--)
                {
                    _allObservers[i].OnNotify("Normal2");
                }
            }
            else
            {
                for (int i = _allObservers.Count - 1; i >= 0; i--)
                {
                    _allObservers[i].OnNotify("Normal1");
                }
            }
        }
    }
    
    public void ShootCrouch(bool flipX)
    {
        if (isCrouch)
        {
            _timer += 1 * Time.deltaTime;
            if (_timer > 0.25f)
            {
                _characterWeapon.ShootCrouch(flipX);
                _timer = 0;
            }
            if (flipX)
            {
                for (int i = _allObservers.Count - 1; i >= 0; i--)
                {
                    _allObservers[i].OnNotify("Down2");
                }
            }
            else
            {
                for (int i = _allObservers.Count - 1; i >= 0; i--)
                {
                    _allObservers[i].OnNotify("Down1");
                }
            }
        }
    }

    public void ShootUp(bool flipX)
    {
        if (isSeeUp)
        {
            _timer += 1 * Time.deltaTime;
            if (_timer > 0.25f)
            {
                _characterWeapon.ShootUp(flipX);
                _timer = 0;
            }
            if (flipX)
            {
                for (int i = _allObservers.Count - 1; i >= 0; i--)
                {
                    _allObservers[i].OnNotify("Up2");
                }
            }
            else
            {
                for (int i = _allObservers.Count - 1; i >= 0; i--)
                {
                    _allObservers[i].OnNotify("Up1");
                }
            }
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
            if (flipX)
            {
                for (int i = _allObservers.Count - 1; i >= 0; i--)
                {
                    _allObservers[i].OnNotify("UF2");
                }
            }
            else
            {
                for (int i = _allObservers.Count - 1; i >= 0; i--)
                {
                    _allObservers[i].OnNotify("UF1");
                }
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
            if (flipX)
            {
                for (int i = _allObservers.Count - 1; i >= 0; i--)
                {
                    _allObservers[i].OnNotify("DF2");
                }
            }
            else
            {
                for (int i = _allObservers.Count - 1; i >= 0; i--)
                {
                    _allObservers[i].OnNotify("DF1");
                }
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
        if (collision.gameObject.tag == "nextLV")
        {
            bool next = true;
            EventsManager.TriggerEvent(EventType.GP_NextLVL, new object[] { next });
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

    public void Subscribe(IObserver observer)
    {
        if (!_allObservers.Contains(observer))
            _allObservers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        if (_allObservers.Contains(observer))
            _allObservers.Remove(observer);
    }

    void MoreHP(params object[] parameters)
    {
        life += (int)parameters[0];
    }

    void MoreSpeed(params object[] parameters)
    {
        speed += (float)parameters[0];
    }

    void Inmortal(params object[] parameters)
    {
        inmortal = (bool)parameters[0];
    }

}
