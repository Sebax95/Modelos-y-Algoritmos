using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierBullet : MonoBehaviour
{
    public float speed;
    public float maxDistance;

    private float _currentDistance;

    public void Reset()
    {
        _currentDistance = 0;
    }

    void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;
        _currentDistance += speed * Time.deltaTime;
        if (_currentDistance > maxDistance)
        {
            SoldierSpawnerPool.Instance.ReturnBullet(this);
        }
    }

    public static void TurnOn(SoldierBullet b)
    {
        b.Reset();
        b.gameObject.SetActive(true);
    }
    public static void TurnOff(SoldierBullet b)
    {
        b.gameObject.SetActive(false);
    }
}

