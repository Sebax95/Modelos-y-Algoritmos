using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootAdvance : IAdvance
{
    EnemySpawnBullet bulletsp;
    Transform target, oR, oL, t;
    float fr, tim;

    public ShootAdvance(EnemySpawnBullet bp, Transform tar, Transform outR, Transform outL, Transform trans, float timer, float fireRate)
    {
        t = trans;
        fr = fireRate;
        tim = timer;
        oR = outR;
        oL = outL;
        bulletsp = bp;
        target = tar;
    }

    public void Advance()
    {
        tim -= 1 * Time.deltaTime;
        if (tim <= 0)
        {
            var bullet = bulletsp.Spawn();
            if (t.transform.position.x < target.transform.position.x)
            {
                bullet.transform.position = oR.transform.position;
                bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -Vector3.Angle(t.transform.position, target.position)));

            }
            else
            {
                bullet.transform.position = oL.transform.position;
                bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 180, -Vector3.Angle(target.position, t.transform.position)));
            }
            tim = fr;
        }
    }
}
