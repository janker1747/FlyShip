using UnityEngine;

[RequireComponent(typeof(InputReader))]
public class ShipShoter: MonoBehaviour
{
    [SerializeField] private GlobalObjectPool _pool;
    [SerializeField] private Transform _firePoint;

    private InputReader _inputReader;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
    }

    private void OnEnable()
    {
        _inputReader.FirePressed += Shoot;
    }

    private void OnDisable()
    {
        _inputReader.FirePressed -= Shoot;
    }

    private void Shoot()
    {
        Bullet bullet = _pool.GetObject();
        bullet.transform.position = _firePoint.position;
        bullet.transform.rotation = Quaternion.Euler(0,0, -90);

        Vector2 direction = _firePoint.right; 
    }
}