using System;
using TMPro;
using UnityEngine;

public class FruitNinjaScoreManager : MonoBehaviour
{
    public static Action win;
    
    [SerializeField] private float TimeToPlay;

    private float _currentTime;
    private int _currentScore;

    [Space(5)]
    [SerializeField] private ScoreMessage scoreMessage;
    [SerializeField] private Transform scoreMessagePosition;

    [Space(5)]
    [SerializeField] private GameObject winScreen;
    
    [Space(5)]
    [SerializeField] private TextMeshProUGUI scoreCounter;
    [SerializeField] private TextMeshProUGUI timeCounter;
    
    [Space(5)]
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private void OnEnable()
    {
        Fruit.giveScore += UpdateScore;

        _currentTime = TimeToPlay;
        UpdateTimer();
    }

    private void OnDisable()
    {
        Fruit.giveScore -= UpdateScore;
    }

    private void Update()
    {
        if(_currentTime < 0f) return;
        
        _currentTime -= Time.deltaTime;
        if (!(TimeToPlay - _currentTime > 1f)) return;
        TimeToPlay -= 1f;
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        if (_currentTime < 0f)
        {
            timeCounter.text = "0:00";
            EndGame();
            return;
        }
        timeCounter.text = $"{Mathf.FloorToInt(_currentTime/60):0}:{_currentTime%60:00}";
    }

    private void UpdateScore(int scoreToAdd)
    {
        var scrMsg = Instantiate(scoreMessage, scoreMessagePosition.position, Quaternion.identity);
        scrMsg.messageText.text = "+ " + scoreToAdd;
        
        _currentScore += scoreToAdd;
        scoreCounter.text = _currentScore.ToString();
    }

    private void FinalScores()
    {
        if(_currentScore > PlayerPrefs.GetInt("highScore"))
            PlayerPrefs.SetInt("highScore",_currentScore);
        
        currentScoreText.text = _currentScore.ToString();
        highScoreText.text = PlayerPrefs.GetInt("highScore").ToString();
    }

    private void EndGame()
    {
        win?.Invoke();
        FinalScores();
        winScreen.SetActive(true);
    }
}
