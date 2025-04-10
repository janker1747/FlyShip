using System;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(ShipShooter))]
[RequireComponent(typeof(ShipCollisionHandler))]
[RequireComponent(typeof(ShipMover))]
[RequireComponent(typeof(ScoreCounter))]
public class Ship : MonoBehaviour , IHealth
{
    private InputReader _inputReader;
    private ShipShooter _shoter;
    private ShipCollisionHandler _collisionHandler;
    private ShipMover _mover;
    private ScoreCounter _scoreCounter;

    public event Action GameOver;

    private void Awake()
    {
        _inputReader = GetComponent<InputReader>();
        _collisionHandler = GetComponent<ShipCollisionHandler>();
        _mover = GetComponent<ShipMover>();
        _shoter = GetComponent<ShipShooter>();
        _scoreCounter= GetComponent<ScoreCounter>();
    }

    private void OnEnable()
    {
        _shoter.Killed += _scoreCounter.AddPoint;
        _collisionHandler.CollisionEnter += Destroy;
        _inputReader.JumpPressed += _mover.Move;
        _inputReader.FirePressed += _shoter.Shoot;
    }

    private void OnDisable()
    {
        _shoter.Killed -= _scoreCounter.AddPoint;
        _collisionHandler.CollisionEnter -= Destroy;
        _inputReader.JumpPressed -= _mover.Move;
        _inputReader.FirePressed -= _shoter.Shoot;
    }

    public void Destroy()
    {
        GameOver?.Invoke(); 
    }
}
