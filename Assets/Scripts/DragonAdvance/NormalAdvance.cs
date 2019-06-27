using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalAdvance : IAdvance
{
    Transform xf;
    float speed = 2;

    public NormalAdvance(Transform transform)
    {
        xf = transform;
    }

    public void Advance()
    {
        xf.transform.position = new Vector3(xf.transform.position.x, Mathf.Sin(Time.time) * speed, xf.transform.position.z);
        xf.transform.right = Vector3.Lerp(xf.transform.right, new Vector3(0, 0, 0), Time.deltaTime * 2f);
    }


}
