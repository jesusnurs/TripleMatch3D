using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public static ScoreSystem Instance { get; private set; }
    
    [SerializeField] private float _startMultiplierTimer;
    
    private int _score;
    private int _multiplier = 1;

    private float _multiplierTimer;
    
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

    private void Update()
    {
        if (_multiplierTimer > 0)
        {
            _multiplierTimer -= Time.deltaTime;
        }
        else
            _multiplier = 1;
    }

    public void UpdateScore()
    {
        _score += _multiplier * 3;
        _multiplier++;
        _multiplierTimer = _startMultiplierTimer;
    }

    public int GetScore()
    {
        return _score;
    }
    
    public int GetMultiplier()
    {
        return _multiplier;
    }
    public float GetMultiplierTimer()
    {
        return _multiplierTimer/_startMultiplierTimer;
    }

    public void AddScoreToPlayer()
    {
        var currentScore = PlayerPrefs.GetInt("score");
        PlayerPrefs.SetInt("score", currentScore + _score);
    }
}
