using UnityEngine;

public class ShipTracker : MonoBehaviour
{
    [SerializeField] private Ship _ship;
    [SerializeField] private float _xOffset;

    private void Update()
    {
        Vector2 position = transform.position;
        position.x = _ship.transform.position.x + _xOffset;
        transform.position = position;
    }
}
