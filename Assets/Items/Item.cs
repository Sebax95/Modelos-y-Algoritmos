using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Animator _animator;
    BoxCollider2D _boxcollider;
    public  CharacterModel _characterModel;
    bool take;
    float timer;

    public virtual void Awake()
    {
        _characterModel = FindObjectOfType<CharacterModel>();
        _animator = GetComponent<Animator>();
        take = false;
    }
    public virtual void Update()
    {
        Take();
    }

    public virtual void Effect()
    { 
    }

    public virtual void Take()
    {
        if(take)
        {
            timer += 1 * Time.deltaTime;
            if(timer > 0.5)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            take = true;
            _animator.SetTrigger("Take");
            this.gameObject.layer = 10;
            Effect(); ;
        }
    }
}
