using System;
using Assets.Script.general;
using UnityEngine;

public class Enemy : MonoBehaviour, IDeadlyObstacle, IDamageable
{
    private EnemyPool _enemyPool;

    public event Action Destroyed;

    public void SetPool(EnemyPool pool)
    {
        _enemyPool = pool;
    }

    public void Destroy()
    {
        Destroyed?.Invoke();
        _enemyPool.ReturnObject(this);
    }
}
