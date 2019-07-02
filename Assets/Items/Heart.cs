using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Item
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Hero")
        {
            take = true;
            int life = 3;
            EventsManager.TriggerEvent(EventType.GP_MoreHp, new object[] { life });

        }
    }

}
