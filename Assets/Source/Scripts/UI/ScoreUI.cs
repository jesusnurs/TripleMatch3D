using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _levelText;
    [SerializeField] private Slider _multiplierSlider;
    [SerializeField] private TextMeshProUGUI _multiplierSliderText;

    private void Start()
    {
        _levelText.text = "Level " + PlayerPrefs.GetInt("level");
    }

    public void Update()
    {
        if (TimerSystem.Instance.isRunning)
        {
            _scoreText.text = ScoreSystem.Instance.GetScore().ToString();
            _multiplierSliderText.text = "x " + ScoreSystem.Instance.GetMultiplier().ToString();
        
            var multiplierTimer = ScoreSystem.Instance.GetMultiplierTimer();

            if (multiplierTimer > 0)
            {
                _multiplierSlider.value = multiplierTimer;
            }
            else
                _multiplierSlider.value = 0;
        }
    }
}
