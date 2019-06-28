using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSoldierAdvance : IAdvance
{
    Transform t;
    Vector2 st;
    float speed = 2;

    public NormalSoldierAdvance(Transform trans, Vector2 startPos)
    {
        t = trans;
        st = startPos;
    }

    public void Advance()
    {
        t.position += t.right * speed * Time.deltaTime;
        var dist = Vector2.Distance(t.position, st);
        if (dist >= 5)
            speed *= -1;
    }
}
