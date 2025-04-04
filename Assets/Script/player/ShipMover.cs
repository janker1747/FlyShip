using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(InputReader))]
public class ShipMover : MonoBehaviour
{
    [SerializeField] private float _tapForce = 5f;
    [SerializeField] private float _speed = 2f;
    [SerializeField] private float _rotationSpeed = 5f;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;

    private Vector3 _startPosition;
    private Rigidbody2D _rigidbody;
    private InputReader _inputReader;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _startPosition = transform.position;
        _rigidbody = GetComponent<Rigidbody2D>();

        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);

        Reset();
    }

    private void OnEnable()
    {
        _inputReader.JumpPressed += Move;
    }

    private void OnDisable()
    {
        _inputReader.JumpPressed -= Move;
    }

    private void Update()
    {
        RotateShip();
    }

    private void Move()
    {
        _rigidbody.velocity = new Vector2(_speed, _tapForce);
    }

    private void RotateShip()
    {
        float targetAngle = Mathf.LerpAngle(_minRotationZ, _maxRotationZ, (_rigidbody.velocity.y + _tapForce) / (_tapForce * 2));

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, targetAngle), _rotationSpeed * Time.deltaTime);
    }

    public void Reset()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        _rigidbody.velocity = Vector2.zero;
    }
}
