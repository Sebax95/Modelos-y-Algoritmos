using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewEnemy : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sp;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
        sp = GetComponentInParent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipLeft()
    {
        sp.flipX = false;
    }
    public void FlipRight()
    {
        sp.flipX = true;
    }
}
