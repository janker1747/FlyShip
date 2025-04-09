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
            Enemy bullet = Instantiate(_prefab);
            bullet.gameObject.SetActive(false);
            _pool.Enqueue(bullet);
        }
    }

    public Enemy GetObject()
    {
        if (_pool.Count > 0)
        {
            Enemy enemy = Instantiate(_prefab);
            return enemy;
        }

        Enemy enemyPool = _pool.Dequeue();
        enemyPool.gameObject.SetActive(true);
        return enemyPool;

    }

    public void ReturnObject(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        _pool.Enqueue(enemy);
    }
}
