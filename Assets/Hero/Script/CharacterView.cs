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
    public float timer = 0.5f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRender = GetComponent<SpriteRenderer>();
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
}
