using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripleBalaAdvance : IAdvance
{
    SoldierSpawnerPool bulletsp;
    Transform target, oR, oL, t;
    float fr, tim;

    public TripleBalaAdvance(SoldierSpawnerPool bp, Transform tar, Transform outR, Transform outL, Transform trans, float timer, float fireRate)
    {
        bulletsp = bp;
        target = tar;
        oR = outR;
        oL = outL;
        t = trans;
        tim = timer;
        fr = fireRate;
    }

    public void Advance()
    {
        tim -= 1 * Time.deltaTime;
        if (tim <= 0)
        {
            int shots = 3;
            while (shots >= 0)
            {
                var bullet = bulletsp.Spawn();
                if (t.transform.position.x < target.transform.position.x)
                {
                    bullet.transform.position = oR.transform.position;
                    if (shots == 3)
                        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 45));
                    else if (shots == 2)
                        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
                    else
                        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 0, -45));

                }
                else
                {
                    bullet.transform.position = oL.transform.position;
                    if (shots == 3)
                        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 45));
                    else if (shots == 2)
                        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 180, 0));
                    else
                        bullet.transform.rotation = Quaternion.Euler(new Vector3(0, 180, -45));
                }
                shots--;
            }
            shots = 3;
            tim = fr;
        }
    }
}
