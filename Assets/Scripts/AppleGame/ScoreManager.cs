using System;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private int goalScore;
    private int _currentScore;
    
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
        if(_currentScore >= goalScore) Debug.Log("U WIN!");
        scoreCounter.text = $"{_currentScore} / {goalScore}";
    }
}
