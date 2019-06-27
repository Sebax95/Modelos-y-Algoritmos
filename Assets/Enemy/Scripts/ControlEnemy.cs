using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlEnemy : IController
{
    Dragon d;
    ViewEnemy v;
    public ControlEnemy (Dragon dr, ViewEnemy ve)
    {
        d = dr;
        v = ve;

        d.OnLeft += v.FlipLeft;
        d.OnRight += v.FlipRight;
        d.OnDead += v.Dead;//Agus
    }

    public void OnUpdate()
    {
        if(d.dead == false)//Agus
        {
            if (d.transform.position.x < d.target.transform.position.x)
                d.FlipR();
            else
                d.FlipL();


            d.output.transform.right = d.transform.position;
            var dist = Vector2.Distance(d.transform.position, d.target.transform.position);
            if (dist <= d.distMax)
            {
                if (dist <= d.distMin)
                {
                    d.myCurrentStrategy = d.myCurrentShoot;
                }
                else
                {
                    d.myCurrentStrategy = d.myCurrentFollow;
                }
            }
            else
            {
                d.myCurrentStrategy = d.myCurrentNormal;
            }
        }
        
    }


}
