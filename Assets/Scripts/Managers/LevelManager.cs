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
    GameObject _Player;
    [SerializeField]
    List<GameObject> _SheepList;

    bool _isLevelStarted = false;
    bool _isLevelEnded = false;
    int _currentLevelNum;

    public int CurrentLevelNum { get { return _currentLevelNum; } }

    private void OnEnable()
    {
        GameEvents.StartLevel += StartGame;
        GameEvents.RestartCurrentScene += ResetCurrentLevel;
        GameEvents.AddSheepToList+= AddSheepToList;
        GameEvents.RemoveSheepFromList += RemoveSheepFromList;
    }
    private void OnDisable()
    {
        GameEvents.StartLevel-= StartGame;
        GameEvents.RestartCurrentScene -= ResetCurrentLevel;
        GameEvents.AddSheepToList -= AddSheepToList;
        GameEvents.RemoveSheepFromList -= RemoveSheepFromList;
    }

    void StartGame()
    {
        _isLevelEnded = false;

        if (_Player != null)
            Destroy(_Player);

        foreach (GameObject sheep in _SheepList)
        {
            Destroy(sheep);
        }
        _SheepList.Clear();

        SpawnPlayer();
        SpawnNewSheep();

        _isLevelStarted= true;
        GameEvents.UnFreezeGame?.Invoke();
    }

    private void Update()
    {
        if (!_isLevelStarted)
            return;

        if (_SheepList.Count == 0 || !_Player.GetComponent<PlayerHealth>().IsAlive)
        {
            _isLevelEnded = true;
        }
    }

    void SpawnPlayer()
    {
       _Player =  Instantiate(_PlayerPrefab);
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

     void AddSheepToList(GameObject sheep)
    {
        _SheepList.Add(sheep);
    }

    void RemoveSheepFromList(GameObject sheep)
    {
        _SheepList.Remove(sheep);
    }
}
