using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : Item
{
    public override void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Hero")
        {
            take = true;
            float speed = 3;
            EventsManager.TriggerEvent(EventType.GP_MoreSpeed, new object[] { speed });
        }

           
    }
}
