using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterPool<T>
{
    public delegate T FactoryMethod();
    List<T> _currentStock;
    FactoryMethod _factoryMethod;
    bool _isDynamic;
    Action<T> _turnOnCallBack;
    Action<T> _turOffCallBack;

    public CharacterPool(FactoryMethod factoryMethod, Action<T> turnOnCallBack, Action<T> turnOffCallBack, int initialStock = 0, bool isDynamic = true)
    {
        _factoryMethod = factoryMethod;
        _isDynamic = isDynamic;
        _turnOnCallBack = turnOnCallBack;
        _turOffCallBack = turnOffCallBack;
        _currentStock = new List<T>();
        for (int i = 0; i < initialStock; i++)
        {
            var o = _factoryMethod();
            _turOffCallBack(o);
            _currentStock.Add(o);
        }
    }

    public T GetObject()
    {
        var result = default(T);
        if (_currentStock.Count > 0)
        {
            result = _currentStock[0];
            _currentStock.RemoveAt(0);
        }
        else if (_isDynamic)
            result = _factoryMethod();
        _turnOnCallBack(result);
        return result;
    }

    public void ReturnObject(T o)
    {
        _turOffCallBack(o);
        _currentStock.Add(o);
    }

}
