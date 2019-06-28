using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectPool<T>
{
    public delegate T FactoryMethod();
    private List<T> _currenStock;
    private FactoryMethod _factotyMethod;
    private bool _isDynamic;
    private Action<T> _turnOnCallback;
    private Action<T> _turnOffCallback;
    
    public ObjectPool(FactoryMethod factoryMethod, Action<T> turnOnCallback, Action<T> turnOffCallback, int initialStock = 0, bool isDynamic = true)
    {
        _factotyMethod = factoryMethod;
        _isDynamic = isDynamic;

        _turnOnCallback = turnOnCallback;
        _turnOffCallback = turnOffCallback;

        _currenStock = new List<T>();

        for (int i = 0; i < initialStock; i++)
        {
            var o = _factotyMethod();
            _turnOffCallback(o);
            _currenStock.Add(o);
        }
    }

    public T GetObject()
    {
        var result = default(T);
        if (_currenStock.Count > 0)
        {
            result = _currenStock[0];
            _currenStock.RemoveAt(0);
        }
        else if (_isDynamic)
            result = _factotyMethod();
        _turnOnCallback(result);
        return result;
    }

    public void ReturnObject(T o)
    {
        _turnOffCallback(o);
        _currenStock.Add(o);
    }
}
