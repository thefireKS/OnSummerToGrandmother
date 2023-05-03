using System;
using TMPro;
using UnityEngine;

public class CatchApplesScoreManager : MonoBehaviour
{
    public static Action win;

    [SerializeField] private int goalScore;
    private int _currentScore;

    [Space(5)]
    [SerializeField] private ScoreMessage scoreMessage;
    [SerializeField] private Transform scoreMessagePosition;

    [Space(5)]
    [SerializeField] private GameObject winScreen;
    
    [SerializeField] private TextMeshProUGUI scoreCounter;

    private void OnEnable()
    {
        UpdateScore();
        Apple.giveScore += AddScore;
    }

    private void OnDisable()
    {
        Apple.giveScore -= AddScore;
    }

    private void AddScore(int score)
    {
        _currentScore += score;

        var scrMsg = Instantiate(scoreMessage, scoreMessagePosition.position, Quaternion.identity);
        scrMsg.messageText.text = SetMessage(score);
        
        UpdateScore();
    }

    private string SetMessage(int score)
    {
        string scoreText;
        if (score > 0)
            scoreText = "+" + score;
        else
            scoreText = score.ToString();
        return scoreText;
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
