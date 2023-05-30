using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _scoreText;

    private int _score;

    public void UpdateScore(int score)
    {
        _score += score;
        _scoreText.text = _score.ToString();
    }

    public int GetScore()
    {
        return _score;
    }
}
