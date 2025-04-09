using System;
using System.Threading;
using UnityEngine;

public class ShipCollisionHandler : MonoBehaviour
{
    public event Action CollisionEnter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out Floor floor))
        {
            CollisionEnter?.Invoke();
        }

        if (collision.collider.TryGetComponent(out Bullet bullet))
        {
            CollisionEnter?.Invoke();
        }

        if (collision.collider.TryGetComponent(out Enemy enemy))
        {
            CollisionEnter?.Invoke();
        }
    }
}
