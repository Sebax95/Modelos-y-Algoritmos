using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBalaAdvance : IAdvance
{
    SoldierSpawnerPool bulletsp;
    Transform target, oR, oL, tr;
    float tim, fr;

    public NormalBalaAdvance(SoldierSpawnerPool bp, Transform tar, Transform outR, Transform outL, Transform trans, float timer, float fireRate)
    {
        bulletsp = bp;
        target = tar;
        oR = outR;
        oL = outL;
        tr = trans;
        tim = timer;
        fr = fireRate;
    }

    public void Advance()
    {
        tim -= 1 * Time.deltaTime;
        if (tim <= 0)
        {
            var bullet = bulletsp.Spawn();
            if (tr.transform.position.x < target.transform.position.x)
            {
                bullet.transform.position = oR.transform.position;
                bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            }
            else
            {
                bullet.transform.position = oL.transform.position;
                bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
            }
            tim = fr;
        }
    }
}
