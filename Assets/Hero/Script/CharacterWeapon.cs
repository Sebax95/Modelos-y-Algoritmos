using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour, IObservable
{
    public BulletRed bulletPrefab;
    public GameObject weapon;
    private static CharacterWeapon _Instance;
    public static CharacterWeapon Instance { get { return _Instance; } }
    private List<IObserver> _allObservers = new List<IObserver>();

    private void Start()
    {
        _Instance = this;
        pool = new ObjectPool<BulletRed>(BulletFactory, BulletRed.TurnOn, BulletRed.TurnOff, 30, true);
    }

    public BulletRed BulletFactory()
    {
        return Instantiate(bulletPrefab);
    }

    private ObjectPool<BulletRed> pool;

    public void ReturnBullet(BulletRed bullet)
    {
        pool.ReturnObject(bullet);
    }

    public void Shoot(bool FlipX)
    {
        var _bullet = pool.GetObject();
        if (!FlipX)
        {
            _bullet.transform.position = weapon.transform.position;
            _bullet.transform.right = transform.right;
        }
        else
        {
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
            _bullet.transform.position = weapon.transform.position;
        }
        else
        {
            _bullet.transform.position = weapon.transform.position;
        }
    }

    public void ShootCrouch(bool FlipX)
    {
        var _bullet = pool.GetObject();
        if (!FlipX)
        {
            _bullet.transform.position = weapon.transform.position;
            _bullet.transform.right = transform.right;
        }
        else
        {
            _bullet.transform.position = weapon.transform.position;
            _bullet.transform.right = -transform.right;
        }
    }

   

    public void ShootFrontUp(bool FlipX)
    {
        var _bullet = pool.GetObject();
        if (!FlipX)
        {
            _bullet.transform.position = weapon.transform.position;
            _bullet.transform.right = transform.up + transform.right;
        }
        else
        {
            _bullet.transform.position = weapon.transform.position;
            _bullet.transform.right = transform.up - transform.right;
        }
    }

    public void ShootFrontDown(bool FlipX)
    {
        var _bullet = pool.GetObject();
        if (!FlipX)
        {
            _bullet.transform.position = weapon.transform.position;
            _bullet.transform.right = -transform.up + transform.right;
        }
        else
        {
            _bullet.transform.position = weapon.transform.position;
            _bullet.transform.right = -transform.up - transform.right;
        }
    }

    public void Subscribe(IObserver observer)
    {
        if (!_allObservers.Contains(observer))
            _allObservers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        if (_allObservers.Contains(observer))
            _allObservers.Remove(observer);
    }
}
