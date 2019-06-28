using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSoldierAdvance : IAdvance
{

    Transform s, t;
    float speed = 3;

    public FollowSoldierAdvance(Transform soldier, Transform target)
    {
        s = soldier;
        t = target;
    }

    public void Advance()
    {
        var dir = (t.transform.position - s.transform.position).normalized;
        dir.z = 0;
        s.transform.position += dir * speed * Time.deltaTime;
    }
}
