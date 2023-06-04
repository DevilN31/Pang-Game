using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    [SerializeField]
    GameObject _PlayerPrefab;
    [SerializeField]
    GameObject _SheepPrefab;

    [SerializeField]
    int _CurrentLevelNum;

    public int CurrentLevelNum { get { return _CurrentLevelNum; } }

    private void OnEnable()
    {
        GameEvents.StartGame += StartGame;
        GameEvents.RestartCurrentScene += ResetCurrentLevel;
    }
    private void OnDisable()
    {
        GameEvents.StartGame-= StartGame;
        GameEvents.RestartCurrentScene -= ResetCurrentLevel;
    }

    void StartGame()
    {
        SpawnPlayer();
        SpawnNewSheep();
    }

    void SpawnPlayer()
    {
        Instantiate(_PlayerPrefab);
    }

    void SpawnNewSheep()
    {
        Instantiate(_SheepPrefab);
    }

    void ResetCurrentLevel()
    {
        GameEvents.UnFreezeGame?.Invoke();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
