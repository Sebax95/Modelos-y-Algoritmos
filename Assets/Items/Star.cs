using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star :Item
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            take = true;
            bool inmortal = true;
            EventsManager.TriggerEvent(EventType.GP_Inmortal, new object[] { inmortal });
        }
          
    }
}
