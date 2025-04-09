using System;
using UnityEngine;


[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(ShipShooter))]
[RequireComponent(typeof(ShipCollisionHandler))]
[RequireComponent(typeof(ShipMover))]
public class Ship : MonoBehaviour
{
    private InputReader _inputReader;
    private ShipShooter _shoter;
    private ShipCollisionHandler _collisionHandler;
    private ShipMover _mover;

    public event Action GameOver;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _collisionHandler = GetComponent<ShipCollisionHandler>();
        _mover = GetComponent<ShipMover>();
        _shoter = GetComponent<ShipShooter>();
    }

    private void OnEnable()
    {
        _collisionHandler.CollisionEnter += Destroy;
        _inputReader.JumpPressed += _mover.Move;
        _inputReader.FirePressed += _shoter.Shoot;
    }

    private void OnDisable()
    {
        _collisionHandler.CollisionEnter -= Destroy;
        _inputReader.JumpPressed -= _mover.Move;
        _inputReader.FirePressed -= _shoter.Shoot;
    }

    public void Destroy()
    {
        GameOver?.Invoke(); 
    }
}
