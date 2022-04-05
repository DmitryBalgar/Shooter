using System;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private PoolObject _prefabObj;
    [SerializeField] private Transform _container;
    [SerializeField] private int _minCapacity;
    [SerializeField] private int _maxCapacity;
    [SerializeField] private bool _autoExpand;

    private List<PoolObject> _pool;

    private void Start()
    {
        CreatePool();
    }
    private void CreatePool()
    {
        _pool = new List<PoolObject>(_minCapacity);
        for (int i = 0; i < _minCapacity; i++)
        {
            CreateElement();
        }
    }

    private PoolObject CreateElement(bool activeByDefault = false)
    {
        var _currentObj = Instantiate(_prefabObj, _container);
        _currentObj.gameObject.SetActive(activeByDefault);

        _pool.Add(_currentObj);

        return _currentObj;
    }

    public bool TryGetElement(out PoolObject element)
    {
        foreach (var item in _pool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                element = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }
        element = null;
        return false;
    }

    public PoolObject GetFreeElement()
    {
        if (TryGetElement(out var element))
        {
            return element;
        }
        if (_autoExpand)
        {
            return CreateElement(true);
        }

        if (_pool.Count < _maxCapacity)
        {
            return CreateElement(true);
        }
        throw new Exception("Pool is over");
    }
    public PoolObject GetFreeElement(Vector3 position)
    {
        var element = GetFreeElement();
        element.transform.position = position;
        return element;
    }
    public PoolObject GetFreeElement(Vector3 position, Quaternion rotation)
    {
        var element = GetFreeElement(position);
        element.transform.rotation = rotation;
        return element;
    }
    public PoolObject GetFreeElement(Vector3 position, Quaternion rotation, Vector3 direction)
    {
        var element = GetFreeElement(position, rotation);
        element.transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(direction));
        return element;
    }

    private static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;

    }


}
