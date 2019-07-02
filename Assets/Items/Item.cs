using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    Animator _animator;
    public bool take;
    bool colision;
    float timer;

    public virtual void Awake()
    {
        _animator = GetComponent<Animator>();
        take = false;
    }
    public virtual void Update()
    {
        Take();
    }

    public virtual void Take()
    {
       
        if(take)
        {
            _animator.SetTrigger("Take");
            timer += 1 * Time.deltaTime;
            if(timer > 0.5)
            {
                gameObject.SetActive(false);
            }
        }
    }
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
   
}
