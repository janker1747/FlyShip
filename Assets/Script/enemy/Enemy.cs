using Assets.Script.general;
using UnityEngine;

public class Enemy : MonoBehaviour, Death
{
    private EnemyPool _enemyPool;

    public void SetPool(EnemyPool pool)
    {
        _enemyPool = pool;
    }

    public void Destroy()
    {
        GameEvents.Instance.OnEnemyDestroyed();
        _enemyPool.ReturnObject(this);
    }
}
