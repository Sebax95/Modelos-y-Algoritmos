using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Item
{
    public override void Effect()
    {
        _characterModel.life += 1;
    }

}
