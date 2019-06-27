using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShoot1
{
    void Shoot(bool FlipX);
    void ShootCrouch(bool FlipX);
    void ShootUp(bool FlipX);
    void ShootFrontUp(bool FlipX);
    void ShootFrontDown(bool FlipX);
}