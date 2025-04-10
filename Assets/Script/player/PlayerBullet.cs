using System;
using UnityEngine;

public class PlayerBullet : Bullet
{
    protected override void OnHit(Collider2D collider)
    {
        if (collider.TryGetComponent(out Enemy enemy))
        {
            enemy.Destroy();
        }

        base.OnHit(collider);
    }
}
