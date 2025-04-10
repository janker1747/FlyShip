using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T> where T : MonoBehaviour
{
    private readonly T _prefab;
    private readonly Queue<T> _pool;

    public ObjectPool(T prefab, int initialSize)
    {
        _prefab = prefab;
        _pool = new Queue<T>();

        for (int i = 0; i < initialSize; i++)
        {
            T obj = Object.Instantiate(_prefab);
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
    }

    public T GetObject()
    {
        if (_pool.Count == 0)
        {
            return Object.Instantiate(_prefab);
        }

        T obj = _pool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void ReturnObject(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }
}
