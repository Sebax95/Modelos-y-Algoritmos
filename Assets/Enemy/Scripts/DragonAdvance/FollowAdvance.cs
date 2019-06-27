using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowAdvance : IAdvance
{
    Transform t, tg;
    float speed = 3;

    public FollowAdvance(Transform tra, Transform target)
    {
        t = tra;
        tg = target;
    }

    public void Advance()
    {
        t.transform.position = new Vector3(t.transform.position.x, Mathf.Clamp(t.transform.position.y, 0, 100), t.transform.position.z);
        var dir = (tg.transform.position - t.transform.position).normalized;
        dir.z = 0;
        t.transform.position += dir  * speed * Time.deltaTime;
    }
}
