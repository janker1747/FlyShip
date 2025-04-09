using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    [SerializeField] Bullet _bullet;
    [SerializeField] int _poolSize = 15;

    private Queue<Bullet> _bullets = new Queue<Bullet>();

    private void Awake()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            Bullet bullet = Instantiate(_bullet);
            bullet.gameObject.SetActive(false);
            _bullets.Enqueue(bullet);
        }
    }

    public virtual Bullet GetObject()
    {
        if (_bullets.Count == 0)
        {
            Bullet bullet = Instantiate(_bullet);
            return bullet;
        }

        Bullet bulletPool = _bullets.Dequeue();
        bulletPool.gameObject.SetActive(true);
        return bulletPool;
    }

    public void ReturnObject(Bullet obj)
    {
        obj.gameObject.SetActive(false);
        _bullets.Enqueue(obj);
    }
}
