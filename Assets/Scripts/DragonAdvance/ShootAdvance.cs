using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootAdvance : MonoBehaviour, IAdvance
{
    Transform xf, tg;
    float fr, t;
    EnemySpawnBullet b;

    public ShootAdvance(Transform x, Transform target, float rateFire, float timer, EnemySpawnBullet bullet)
    {
        xf = x;
        tg = target;
        fr = rateFire;
        t = timer;
        b = bullet;
    }

    public void Advance()
    {
        t -= 1 * Time.deltaTime;
        if (t <= 0)
        {
            var bull = b.Spawn();
            bull.transform.right = tg.transform.position;
            t = fr;
        }
    }
}
