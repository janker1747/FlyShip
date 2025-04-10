using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Enemy _prefab;
    [SerializeField] private int _poolSize = 10;

    private ObjectPool<Enemy> _pool;

    private void Awake()
    {
        _pool = new ObjectPool<Enemy>(_prefab, _poolSize);
    }

    public Enemy GetObject()
    {
        Enemy enemy = _pool.GetObject();
        enemy.SetPool(this);
        return enemy;
    }

    public void ReturnObject(Enemy enemy)
    {
        _pool.ReturnObject(enemy);
    }
}
