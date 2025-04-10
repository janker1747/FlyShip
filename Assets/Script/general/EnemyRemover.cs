using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    [SerializeField] private EnemyPool _pool;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.TryGetComponent(out Enemy enemy))
        {
            _pool.ReturnObject(enemy);
        }
    }
}
