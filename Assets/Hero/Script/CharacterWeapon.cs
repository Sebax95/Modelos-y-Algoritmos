using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour, IShoot1
{
    public BulletRed bulletPrefab;
    public GameObject weapon;
    private static CharacterWeapon _Instance;
    public static CharacterWeapon Instance { get { return _Instance; } }

    private void Start()
    {
        _Instance = this;
        pool = new CharacterPool<BulletRed>(BulletFactory, BulletRed.TurnOn, BulletRed.TurnOff, 30, true);
    }

    public BulletRed BulletFactory()
    {
        return Instantiate(bulletPrefab);
    }

    private CharacterPool<BulletRed> pool;

    public void ReturnBullet(BulletRed bullet)
    {
        pool.ReturnObject(bullet);
    }

    public void Shoot(bool FlipX)
    {
        var _bullet = pool.GetObject();
        if (!FlipX)
        {
           
            weapon.transform.position = transform.position + new Vector3(0.5f, 0.70f, 0);
            _bullet.transform.position = weapon.transform.position;
            _bullet.transform.right = transform.right;
        }
        else
        {
            weapon.transform.position = transform.position + new Vector3(-0.5f, 0.70f, 0);
            _bullet.transform.position = weapon.transform.position;
            _bullet.transform.right = -transform.right;
        }
      
    }

    public void ShootCrouch(bool FlipX)
    {
        var _bullet = pool.GetObject();
        if (!FlipX)
        {
             weapon.transform.position = transform.position + new Vector3(0.5f, 0.2f, 0);
            _bullet.transform.position = weapon.transform.position;
            _bullet.transform.right = transform.right;
        }
        else
        {
            weapon.transform.position = transform.position + new Vector3(-0.5f, 0.2f, 0);
            _bullet.transform.position = weapon.transform.position;
            _bullet.transform.right = -transform.right;
        }
    }

    public void ShootUp(bool FlipX)
    {
        var _bullet = pool.GetObject();
        _bullet.transform.right = transform.up;
        if (!FlipX)
        {
            weapon.transform.position = transform.position + new Vector3(0.1f,1.35f, 0);
            _bullet.transform.position = weapon.transform.position;
        }
        else
        {
            weapon.transform.position = transform.position + new Vector3(-0.1f, 1.35f, 0);
            _bullet.transform.position = weapon.transform.position;
        }
    }

    public void ShootFrontUp(bool FlipX)
    {
        var _bullet = pool.GetObject();
        if (!FlipX)
        {
            weapon.transform.position = transform.position + new Vector3(0.35f, 1, 0);
            _bullet.transform.position = weapon.transform.position;
            _bullet.transform.right = transform.up + transform.right;
        }
        else
        {
            weapon.transform.position = transform.position + new Vector3(-0.45f, 1.1f, 0);
            _bullet.transform.position = weapon.transform.position;
            _bullet.transform.right = transform.up - transform.right;
        }
    }

    public void ShootFrontDown(bool FlipX)
    {
        var _bullet = pool.GetObject();
        if (!FlipX)
        {
            weapon.transform.position = transform.position + new Vector3(0.45f, 0.4f, 0);
            _bullet.transform.position = weapon.transform.position;
            _bullet.transform.right = -transform.up + transform.right;
        }
        else
        {
            weapon.transform.position = transform.position + new Vector3(-0.45f, 0.4f, 0);
            _bullet.transform.position = weapon.transform.position;
            _bullet.transform.right = -transform.up - transform.right;
        }
    }
}
