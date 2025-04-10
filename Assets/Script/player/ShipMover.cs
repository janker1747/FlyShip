using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMover : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float _tapForce = 5f;
    [SerializeField] private float _horizontalSpeed = 2f;

    [Header("Rotation Settings")]
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _maxRotationZ = 30f;
    [SerializeField] private float _minRotationZ = -90f;

    [Header("Initial State")]
    [SerializeField] private float _resetRotationZ = -90f;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;

        _rigidbody.freezeRotation = true;

        Reset();
    }

    private void Update()
    {
        RotateShip();
    }

    public void Move()
    {
        _rigidbody.velocity = new Vector2(_horizontalSpeed, _tapForce);
    }

    private void RotateShip()
    {
        float maxVerticalVelocity = _tapForce * 2f;
        float normalizedY = (_rigidbody.velocity.y + _tapForce) / maxVerticalVelocity;
        float targetZ = Mathf.Lerp(_minRotationZ, _maxRotationZ, normalizedY);

        Quaternion targetRotation = Quaternion.Euler(0, 0, targetZ);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, _resetRotationZ);
        _rigidbody.velocity = Vector2.zero;
    }
}
