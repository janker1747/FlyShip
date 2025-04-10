using UnityEngine;

public class EnemyBullet : Bullet
{
    protected override void OnHit(Collider2D collider)
    {
        if (collider.TryGetComponent(out Ship ship))
        {
            ship.Destroy();
        }

        base.OnHit(collider);
    }
}
