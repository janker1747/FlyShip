using UnityEngine;

public class EnemyShooter : Shooter<Bullet>
{
    [SerializeField] private float _delay = 15f;

    protected override Vector2 GetDirection()
    {
        return transform.up;
    }

    protected override float ShootDelay => _delay;
}
