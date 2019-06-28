using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackSoldierAdvance : IAdvance
{
    Transform t;
    Vector3 sp;
    float speed = 2;

    public BackSoldierAdvance(Transform pos, Vector3 starPos)
    {
        t = pos;
        sp = starPos;
    }

    public void Advance()
    {
        var dir = (sp - t.position).normalized;
        t.position += dir * speed * Time.deltaTime;
    } 
}
