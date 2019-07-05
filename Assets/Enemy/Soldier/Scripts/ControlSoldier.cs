using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSoldier : MonoBehaviour, IController
{
    Soldier s;
    ViewSoldier v;
    public ControlSoldier(Soldier sol, ViewSoldier vs)
    {
        s = sol;
        v = vs;

        s.OnLeft += v.FlipLeft;
        s.OnRight += v.FlipRight;
        s.OnGetDmg += v.Damage;
        s.OnShoot += v.Shoot;
        s.OnWalk += v.Walk;
        s.OnDead += v.Dead;//Agus
    }

    public void OnUpdate()
    {
        if (s.dead == false)//Agus
        {
            if (s.transform.position.x < s.target.transform.position.x)
                s.FlipR();
            else
                s.FlipL();


             var dist = Vector2.Distance(s.transform.position, s.target.transform.position);
             if (dist <= s.distMax)
             {
                if (dist <= s.distMin)
                {
                    s.Shoot();
                    s.myCurrentStrategy = s.strategyBalaActual;

                }
                else
                {
                    s.Walk();
                    s.myCurrentStrategy = s.myCurrentFollow;
                }
             }
             else
             {
                s.Walk();
                if (Vector2.Distance(s.transform.position, s.startPos) >= 5)
                    s.myCurrentStrategy = s.myCurrentBack;
                else
                    s.myCurrentStrategy = s.myCurrentNormal;

             }
        }
    }
}