using UnityEngine;

public class ShipShooter : Shooter<Bullet>
{
    protected override Vector2 GetDirection()
    {
        return transform.up;
    }
}
