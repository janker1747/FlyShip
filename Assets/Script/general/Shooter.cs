using System;
using System.Collections;
using System.IO;
using UnityEngine;

public abstract class Shooter : MonoBehaviour
{
    [SerializeField] private BulletPool _pool;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private float _bulletLifetime = 3f;
    [SerializeField] private float _shootDelay = 0f;

    private WaitForSeconds _shootDelayWait;
    private WaitForSeconds _bulletLifetimeWait;

    private Coroutine _shootCoroutine;
    private bool _isShooting;

    public event Action Killed;

    protected virtual void Awake()
    {
        _shootDelayWait = new WaitForSeconds(_shootDelay);
        _bulletLifetimeWait = new WaitForSeconds(_bulletLifetime);
    }

    protected virtual void Start()
    {
        if (_shootDelay > 0f)
        {
            StartShooting();
        }
    }

    protected virtual void OnDisable()
    {
        StopShooting();
    }

    protected virtual Vector2 GetDirection()
    {
        return transform.up;
    }

    protected void StartShooting()
    {
        _isShooting = true;
        _shootCoroutine = StartCoroutine(ShootingLoop());
    }

    protected void StopShooting()
    {
        _isShooting = false;

        if (_shootCoroutine != null)
        {
            StopCoroutine(_shootCoroutine);
        }
    }

    private IEnumerator ShootingLoop()
    {
        while (_isShooting)
        {
            Shoot();
            yield return _shootDelayWait;
        }
    }

    public void Shoot()
    {
        Bullet bullet = _pool.GetObject();
        bullet.KilledEnemy += NotifyKilledEnemy;
        bullet.transform.SetPositionAndRotation(_firePoint.position, _firePoint.rotation);
        bullet.SetDirection(GetDirection());
        bullet.BulletHit += OnBulletHit;

        StartCoroutine(ReturnBulletAfterDelay(bullet));
    }

    private void NotifyKilledEnemy()
    {
        Killed?.Invoke();
    }

    private void OnBulletHit(Bullet bullet)
    {
        bullet.BulletHit -= OnBulletHit;
        _pool.ReturnObject(bullet);
    }

    private IEnumerator ReturnBulletAfterDelay(Bullet bullet)
    {
        yield return _bulletLifetimeWait;

        if (bullet.gameObject.activeSelf)
        {
            bullet.BulletHit -= OnBulletHit;
            _pool.ReturnObject(bullet);
        }
    }
}
