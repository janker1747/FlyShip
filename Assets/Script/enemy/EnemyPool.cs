using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _poolSize = 10;

    private Queue<Enemy> _pool = new Queue<Enemy>();

    private void Awake()
    {
        for (int i = 0; i < _poolSize; i++)
        {
            Enemy enemy = Instantiate(_prefab);
            enemy.SetPool(this);
            enemy.gameObject.SetActive(false);
            _pool.Enqueue(enemy);
        }
    }

    public Enemy GetObject()
    {
        Enemy enemy;

        if (_pool.Count > 0)
        {
            enemy = _pool.Dequeue();
        }
        else
        {
            enemy = Instantiate(_prefab);
            enemy.SetPool(this); 
        }

        enemy.gameObject.SetActive(true);
        return enemy;
    }

    public void ReturnObject(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        _pool.Enqueue(enemy);
    }
}
