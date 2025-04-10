using UnityEngine;

public class ShipShooter : Shooter
{
    protected override Vector2 GetDirection()
    {
        return transform.up;
    }
}
