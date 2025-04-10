using Assets.Script.general;
using System;
using UnityEngine;

public abstract class Bullet : MonoBehaviour, IDeadlyObstacle
{
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float _rayLengthMultiplier = 1.5f;
    [SerializeField] private LayerMask _enemyMask;

    private Vector2 _direction;
    private Vector3 _lastPosition;

    public event Action<Bullet> BulletHit;
    public event Action KilledEnemy;

    public void SetDirection(Vector2 direction)
    {
        _direction = direction.normalized;
        _lastPosition = transform.position;
        gameObject.SetActive(true);
    }

    protected virtual void OnHit(Collider2D collider)
    {
        BulletHit?.Invoke(this);

        if (collider.TryGetComponent(out IDamageable health))
        {
            KilledEnemy?.Invoke();
        }

        gameObject.SetActive(false);
    }

    private void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 nextPosition = currentPosition + (Vector3)(_direction * _speed * Time.deltaTime);
        Vector3 rayDirection = nextPosition - currentPosition;
        float rayLength = rayDirection.magnitude * _rayLengthMultiplier;

        RaycastHit2D hit = Physics2D.Raycast(currentPosition, rayDirection.normalized, rayLength, _enemyMask);

        if (hit.collider != null)
        {
            OnHit(hit.collider);
            return;
        }

        transform.position = nextPosition;
    }
}
