using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterView : MonoBehaviour
{
    SpriteRenderer spriteRender;
    Animator animator;
    public Text life;
    public bool flipX;
    bool inmortal;
    public float timer = 0.25f;

    private void Awake()
    {
        inmortal = false;
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (inmortal)
            StartCoroutine(Inmortalll());
    }

    public void Jump(bool isjump)
    {
        animator.SetBool("Jump", isjump);
    }
    public void Run(bool isRun)
    {
        animator.SetBool("Run", isRun);
    }
    public void Crouch(bool isCrouch)
    {
        animator.SetBool("Crouch", isCrouch);
    }
    public void ShootRun(bool isShooting)
    {
        animator.SetBool("Shoot", isShooting);
    }
    public void ShootUp(bool isLookingUp)
    {
        animator.SetBool("ShootUp", isLookingUp);
    }
    public void ShootFUP(bool isShootFUP)
    {
        animator.SetBool("ShootFUP", isShootFUP);
    }
    public void ShootDUP(bool isShootDUP)
    {
        animator.SetBool("ShootDUP", isShootDUP);
    }
    public void Dead(bool isDead)
    {
        animator.SetBool("Dead", isDead);
    }
    public void Damage()
    {
        if (!animator.GetBool("Dead"))
            StartCoroutine(animDamage());
    }
    public void Inmortal(bool isInmortal)
    {
        inmortal = isInmortal;
    }

    IEnumerator animDamage()
    {
        spriteRender.color = Color.red;
        yield return new WaitForSeconds(timer);
        spriteRender.color = Color.white;
        yield return new WaitForSeconds(timer);
        spriteRender.color = Color.red;
        yield return new WaitForSeconds(timer);
        spriteRender.color = Color.white;
    }
    IEnumerator Inmortalll()
    {
        for (int i = 0; i < 3; i++)
        {
            spriteRender.color = Color.yellow;
            yield return new WaitForSeconds(timer);
            spriteRender.color = Color.white;
            yield return new WaitForSeconds(timer);
        }
    }
}
