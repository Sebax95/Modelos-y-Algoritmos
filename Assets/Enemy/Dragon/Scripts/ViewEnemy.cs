using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewEnemy : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sp;
    public float timer = 0.5f;

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
    public void Dead(bool isDead)//Agus
    {
        sp.color = Color.white;
        anim.SetBool("Dead", isDead);
    }
    public void Damage()
    {
        StartCoroutine(animDamage());
    }
    IEnumerator animDamage()
    {
        sp.color = Color.red;
        yield return new WaitForSeconds(timer);
        sp.color = Color.white;
        yield return new WaitForSeconds(timer);
        sp.color = Color.red;
        yield return new WaitForSeconds(timer);
        sp.color = Color.white;
    }
    

}
