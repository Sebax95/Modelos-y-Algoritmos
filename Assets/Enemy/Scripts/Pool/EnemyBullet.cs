using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public float maxDistance;
    public CircleCollider2D _box;//Agus

    private float _currentDistance;

    public void Reset()
    {
        _currentDistance = 0;
        _box.enabled = true;// Agus
    }

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        _currentDistance += speed * Time.deltaTime;
        if (_currentDistance > maxDistance)
        {
            EnemySpawnBullet.Instance.ReturnBullet(this);
        }
    }

    public static void TurnOn(EnemyBullet b)
    {
        b.Reset();
        b.gameObject.SetActive(true);
    }
    public static void TurnOff(EnemyBullet b)
    {
        b.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)//Agus
    {
        if (collision.gameObject.tag == "Hero")
            _box.enabled = false;
    }
}
