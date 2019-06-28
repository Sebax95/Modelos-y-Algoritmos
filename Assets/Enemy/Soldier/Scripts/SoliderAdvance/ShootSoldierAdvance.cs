using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSoldierAdvance : IAdvance
{
    Soldier s;
    float fr, t;

    public ShootSoldierAdvance(Soldier sol, float rateFire, float timer)
    {
        s = sol;
        fr = rateFire;
        t = timer;
    }

    public void Advance()
    {
        t -= 1 * Time.deltaTime;
        if (t <= 0)
        {
            s.ShootBullet();
            t = fr;
        }
    }
}
