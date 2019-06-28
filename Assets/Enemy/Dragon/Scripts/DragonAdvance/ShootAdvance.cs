using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootAdvance : IAdvance
{
    Dragon xf;
    float fr, t;

    public ShootAdvance(Dragon d, float rateFire, float timer)
    {
        xf = d;
        fr = rateFire;
        t = timer;
    }

    public void Advance()
    {
        t -= 1 * Time.deltaTime;
        if (t <= 0)
        {
            xf.ShootBullet();
            t = fr;
        }
    }
}
