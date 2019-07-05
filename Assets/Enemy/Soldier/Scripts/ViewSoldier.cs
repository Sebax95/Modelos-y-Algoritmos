using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewSoldier : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sp;
    public float timer = 0.5f;
    public Color startColor;

    void Start()
    {
        anim = GetComponentInParent<Animator>();
        sp = GetComponentInParent<SpriteRenderer>();
        startColor = sp.color;
    }
    public void FlipLeft()
    {
        sp.flipX = true;
    }
    public void FlipRight()
    {
        sp.flipX = false;
    }
    public void Dead(bool isDead)//Agus
    {
        sp.color = startColor;
        anim.SetBool("Dead", isDead);
    }
    public void Shoot()
    {
        anim.SetTrigger("Shoot");
    }
    public void Walk()
    {
        anim.SetTrigger("Walk");
    }

    public void Damage()
    {
        StartCoroutine(animDamage());
    }
    IEnumerator animDamage()
    {
        sp.color = Color.red;
        yield return new WaitForSeconds(timer);
        sp.color = startColor;
        yield return new WaitForSeconds(timer);
        sp.color = Color.red;
        yield return new WaitForSeconds(timer);
        sp.color = startColor;
    }


}
