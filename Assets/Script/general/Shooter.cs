using System.Collections;
using UnityEngine;
using System;

public abstract class Shooter<T> : MonoBehaviour where T : Bullet
{
    [SerializeField] private BulletPool _pool;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _bulletLifetime = 3f;

    protected abstract Vector2 GetDirection(); 

    protected virtual float ShootDelay => 0f; 

    private Coroutine _shootCoroutine;
    private bool _isShooting;

    protected virtual void Start()
    {
        if (ShootDelay > 0)
            StartShooting();
    }

    protected virtual void OnDisable()
    {
        StopShooting();
    }

    protected void StartShooting()
    {
        if (_isShooting) return;

        _isShooting = true;
        _shootCoroutine = StartCoroutine(ShootingLoop());
    }

    protected void StopShooting()
    {
        if (!_isShooting) return;

        _isShooting = false;
        if (_shootCoroutine != null)
            StopCoroutine(_shootCoroutine);
    }

    private IEnumerator ShootingLoop()
    {
        WaitForSeconds delay = new WaitForSeconds(ShootDelay);

        while (_isShooting)
        {
            Shoot();
            yield return delay;
        }
    }

    public void Shoot()
    {
        T bullet = _pool.GetObject() as T;
        bullet.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
        bullet.SetDirection(GetDirection());
        bullet.BulletHit += OnBulletHit;

        StartCoroutine(ReturnBulletAfterDelay(bullet));
    }

    private void OnBulletHit(Bullet bullet)
    {
        bullet.BulletHit -= OnBulletHit;
        _pool.ReturnObject(bullet);
    }

    private IEnumerator ReturnBulletAfterDelay(Bullet bullet)
    {
        yield return new WaitForSeconds(_bulletLifetime);

        if (bullet.gameObject.activeSelf)
        {
            bullet.BulletHit -= OnBulletHit;
            _pool.ReturnObject(bullet);
        }
    }
}
