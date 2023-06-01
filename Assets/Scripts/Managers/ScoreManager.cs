using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    int _Score = 0;

    public int Score { get { return _Score; } }

    private void OnEnable()
    {
        GameEvents.AddScore += AddScore;
    }

    private void OnDisable()
    {
        GameEvents.AddScore -= AddScore;
    }

    void AddScore()
    {
        _Score++;
        GameEvents.UpdateGameUi?.Invoke();
    }
}
