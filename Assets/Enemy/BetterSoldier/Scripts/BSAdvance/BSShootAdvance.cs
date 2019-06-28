using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BSShootAdvance : IAdvance
{
    BestSoldier bs;
    float fr, t;

    public BSShootAdvance(BestSoldier best, float ratefire, float time)
    {
        bs = best;
        fr = ratefire;
        t = time;
    }

    public void Advance()
    {
        t -= 1 * Time.deltaTime;
        if (t <= 0)
        {
            bs.ShootBullet();
            t = fr;
        }
    }
}
