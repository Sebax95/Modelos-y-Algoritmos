using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star :Item
{
    public override void Effect()
    {
        _characterModel.inmortal = true;
    }
}
