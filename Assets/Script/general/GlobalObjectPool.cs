using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalObjectPool : MonoBehaviour 
{
    [SerializeField] Bullet _bullet;
    [SerializeField] int _poolSize = 10;

    protected Queue<Bullet> _bullets = new Queue<Bullet>();

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

        Bullet poolBullet = _bullets.Dequeue();
        poolBullet.gameObject.SetActive(true);
        return poolBullet;
    }

    public void ReturnObject(Bullet obj)
    {
        obj.gameObject.SetActive(false);
        _bullets.Enqueue(obj);
    }
}
