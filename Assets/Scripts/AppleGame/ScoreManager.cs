using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static Action win;

    [SerializeField] private int goalScore;
    private int _currentScore;

    [SerializeField] private GameObject winScreen;
    
    [SerializeField] private TextMeshProUGUI scoreCounter;

    private void OnEnable()
    {
        UpdateScore();
    }

    public void AddScore(int score)
    {
        _currentScore += score;
        UpdateScore();
    }

    private void UpdateScore()
    {
        if(_currentScore >= goalScore) Win();
        scoreCounter.text = $"{_currentScore:00}/{goalScore:00}";
    }

    private void Win()
    {
        win?.Invoke();
        winScreen.SetActive(true);
    }
}
