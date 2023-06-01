using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [Header("Script References")]
    [SerializeField]
    ScoreManager _ScoreManager;

    [Header("Ui References")]
    [SerializeField]
    TextMeshProUGUI _ScoreText;

    private void OnEnable()
    {
        GameEvents.UpdateGameUi += UpdateScoreText;

    }

    private void OnDisable()
    {
        GameEvents.UpdateGameUi -= UpdateScoreText;
    }

    void Start()
    {
        UpdateScoreText();
    }

    void Update()
    {
        
    }

    void UpdateScoreText()
    {
        _ScoreText.text = $"Score: {_ScoreManager.Score}";

    }
}
