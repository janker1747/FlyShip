using UnityEngine;
using System;

public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance { get; private set; }

    public event Action EnemyDestroyed;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    public void OnEnemyDestroyed()
    {
        EnemyDestroyed?.Invoke();
    }
}
