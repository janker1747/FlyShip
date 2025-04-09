using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    private int _count;

    public event Action<int> OnScoreChanged;
    public int CurrentScore => _count;

    private void OnEnable()
    {
        GameEvents.Instance.EnemyDestroyed += AddPoint;
    }

    private void OnDisable()
    {
        GameEvents.Instance.EnemyDestroyed -= AddPoint;
    }

    private void AddPoint()
    {
        _count++;
        OnScoreChanged?.Invoke(_count);
    }

    public void ResetScore()
    {
        _count = 0;
        OnScoreChanged?.Invoke(_count);
    }
}
