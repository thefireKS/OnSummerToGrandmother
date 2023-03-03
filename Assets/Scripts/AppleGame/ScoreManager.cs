using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
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
        Time.timeScale = 0f;
        winScreen.SetActive(true);
    }
}
