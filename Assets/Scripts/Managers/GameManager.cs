using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool _isPlayerWon;

    private void OnEnable()
    {
        GameEvents.LevelEnded += CheckWinCondition;
    }
    private void OnDisable()
    {
        GameEvents.LevelEnded -= CheckWinCondition;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void CheckWinCondition()
    {
        if (LevelManager.Instance == null)
        {
            Debug.LogError("<GameManager> No Level Manager found");
            return;
        }

        if (LevelManager.Instance.IsPlayerAlive && LevelManager.Instance.SheepCount == 0)
        {
            GameEvents.PlayerWin?.Invoke();
        }

        if (!LevelManager.Instance.IsPlayerAlive)
        {
            GameEvents.PlayerDeath?.Invoke();
        }
    }
}
