using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    int _Score = 0;
    [SerializeField]
    Transform _ScoreboardHolder;
    [SerializeField]
    TextMeshProUGUI _ScoreTextPrefab;

    const string SCORE_KEY = "Scores";
    List<int> _scoreArr;
    Savedscores _savedScores;

    public int Score { get { return _Score; } }
    public List<int> SavedScores { get { return _scoreArr; } }

    private void OnEnable()
    {
        GameEvents.AddScore += AddScore;
        GameEvents.PlayerDeath += SaveHighScore;
        GameEvents.ReloadHighScores += LoadHighScores;
    }

    private void OnDisable()
    {
        GameEvents.AddScore -= AddScore;
        GameEvents.PlayerDeath -= SaveHighScore;
        GameEvents.ReloadHighScores -= LoadHighScores;


    }

    private void Awake()
    {
        LoadHighScores();
    }

    void AddScore(int amount)
    {
        _Score+= amount;
        GameEvents.UpdateGameUi?.Invoke();
    }

    void SaveHighScore()
    {
        if (_scoreArr.Contains(_Score))
            return;

        if (_scoreArr.Count < 5)
        {
            _scoreArr.Add(_Score);
            _scoreArr.Sort(); // Sort int array
            _scoreArr.Reverse(); // Reverse array to show acsending numbers.
            _savedScores.ScoreList = _scoreArr;

            SaveLoadManager.Instance.SaveString(SCORE_KEY, JsonUtility.ToJson(_savedScores));
        }
        else
        {
            if (_Score > _scoreArr[_scoreArr.Count - 1])
            {
                _scoreArr[_scoreArr.Count - 1] = _Score;
                _scoreArr.Sort(); // Sort int array
                _scoreArr.Reverse(); // Reverse array to show acsending numbers.
                _savedScores.ScoreList = _scoreArr;

                SaveLoadManager.Instance.SaveString(SCORE_KEY, JsonUtility.ToJson(_savedScores));

            }
            else
                Debug.Log($"Data Manager: SCORE {_Score} WWASN'T ADDED DUE - LOWER THEN THE LAST SAVED SCORE {_scoreArr[_scoreArr.Count - 1]}");
        }
    }

    void LoadHighScores()
    {
        if(!PlayerPrefs.HasKey(SCORE_KEY))
        {
            _savedScores = new Savedscores();
            _scoreArr = new List<int>();
            Debug.LogError("<ScoreManager> No scores saved yet");
            return;
        }

        _savedScores = JsonUtility.FromJson<Savedscores>(SaveLoadManager.Instance.LoadString(SCORE_KEY));
        _scoreArr = _savedScores.ScoreList;

        if(_ScoreboardHolder.childCount > 0)
        {
            
            for(int i = 0; i< _ScoreboardHolder.childCount; i++) 
            {
                print("in");
                Destroy(_ScoreboardHolder.GetChild(i).gameObject);
            }
        }

        for(int i = 0; i<_scoreArr.Count;i++)
        {
            TextMeshProUGUI temp = Instantiate(_ScoreTextPrefab, _ScoreboardHolder);
            temp.text = $"{i + 1}. {_scoreArr[i]}";
        }

    }
}

class Savedscores
{
    public List<int> ScoreList;
}
