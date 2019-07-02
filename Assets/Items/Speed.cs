using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Speed : Item
{
    public override void Effect()
    {
        _characterModel.speed += 3 ;
    }
}
