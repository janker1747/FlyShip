using UnityEngine;

public class EnemyShooter : Shooter
{
    protected override Vector2 GetDirection()
    {
        return transform.up;
    }
}
