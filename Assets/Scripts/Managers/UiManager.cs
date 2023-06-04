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
    [SerializeField]
    GameObject _ScorePanel;
    [SerializeField]
    GameObject _MenuCanvas;
    [SerializeField]
    GameObject _GameMenuCanvas;
    [SerializeField]
    GameObject _GameOverPanel;
    [SerializeField]
    TextMeshProUGUI _FinalScoreText;
    [SerializeField]
    GameObject _PlayerControllerCanvas;
    [SerializeField]
    GameObject _ScoreboardPanel;
    [SerializeField]
    GameObject _OpenMenuButton;

    private void OnEnable()
    {
        GameEvents.UpdateGameUi += UpdateScoreText;
        GameEvents.PlayerDeath += ShowGameOverPanel;

    }

    private void OnDisable()
    {
        GameEvents.UpdateGameUi -= UpdateScoreText;
        GameEvents.PlayerDeath -= ShowGameOverPanel;

    }

    void Start()
    {
        UpdateScoreText();
        _MenuCanvas.SetActive(true);
        HideOnStart();
    }

    void HideOnStart()
    {
        _ScorePanel.SetActive(false);
        _PlayerControllerCanvas.SetActive(false);
        _ScoreboardPanel.SetActive(false);
        _GameMenuCanvas.SetActive(false);
        _GameOverPanel.SetActive(false);
        _OpenMenuButton.SetActive(false);
    }

    void UpdateScoreText()
    {
        _ScoreText.text = $"Score: {_ScoreManager.Score.ToString("0,0")}";
        _FinalScoreText.text = $"Final Score: {_ScoreManager.Score.ToString("0,0")}";
    }

    public void ShowMenuButton()
    {
        _GameMenuCanvas.SetActive(true);
        GameEvents.FreezeGame?.Invoke();
    }

    void ShowGameOverPanel()
    {
        StartCoroutine(DelayedPanelShow(_GameOverPanel, 1));
        _PlayerControllerCanvas.SetActive(false);
        _ScorePanel.SetActive(false);
        _OpenMenuButton.SetActive(false);
    }

    IEnumerator DelayedPanelShow(GameObject panel, float delay)
    {
        yield return new WaitForSeconds(delay);
        panel.SetActive(true);
    }

    public void PlayButton()
    {
        _MenuCanvas.SetActive(false);
        _ScorePanel.SetActive(true);
        _PlayerControllerCanvas.SetActive(true);
        _OpenMenuButton.SetActive(true);

        GameEvents.StartLevel?.Invoke();

    }

    public void ResumeButton()
    {
        GameEvents.UnFreezeGame?.Invoke();
    }

    public void ResetButton()
    {
        GameEvents.RestartCurrentScene?.Invoke();
    }

    public void ScoreboardButton()
    {
         _ScoreboardPanel.SetActive(true);
        GameEvents.ReloadHighScores?.Invoke();
        _MenuCanvas.SetActive(false);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
