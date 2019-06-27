using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRed : MonoBehaviour
{ 
    public float speed;
    
    void Update()
    {
       transform.position += transform.right * speed * Time.deltaTime;
    }

    private void Reset()
    {
        
    }

    public static void TurnOn(BulletRed b)
    {
        b.Reset();
        b.gameObject.SetActive(true);
    }

    public static void TurnOff(BulletRed b)
    {
        b.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject)
        {
            CharacterWeapon.Instance.ReturnBullet(this);
        }
    }
}
