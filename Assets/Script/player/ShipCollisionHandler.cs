using System;
using Assets.Script.general;
using UnityEngine;

public class ShipCollisionHandler : MonoBehaviour 
{
    public event Action CollisionEnter;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.TryGetComponent(out IDeadlyObstacle death))
        {
            CollisionEnter?.Invoke();
        }
    }
}
