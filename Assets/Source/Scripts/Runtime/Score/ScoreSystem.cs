using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance { get; private set; }
    
    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score;
    
    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        GameStateCallBacks.Instance.OnGameWon += AddScoreToPlayer;
    }

    public void UpdateScore(int score)
    {
        _score += score;
        _scoreText.text = _score.ToString();
    }

    public int GetScore()
    {
        return _score;
    }

    public void AddScoreToPlayer()
    {
        var currentScore = PlayerPrefs.GetInt("score");
        PlayerPrefs.SetInt("score", currentScore + _score);
    }
}
