using System;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _prefab;
    [SerializeField] private int _poolSize = 15;

    private ObjectPool<Bullet> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Bullet>(_prefab, _poolSize);
    }

    public Bullet GetObject()
    {
        return _pool.GetObject();
    }

    public void ReturnObject(Bullet bullet)
    {
        _pool.ReturnObject(bullet);
    }
}
