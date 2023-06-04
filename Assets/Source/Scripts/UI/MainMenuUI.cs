using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MainMenuUI : UIElement
{
    [SerializeField] private Button _playButton;

    [SerializeField] private TextMeshProUGUI _levelCountText;
    [SerializeField] private TextMeshProUGUI _scoreWoodenChest;
    [SerializeField] private TextMeshProUGUI _scoreGoldenChest;
    [SerializeField] private TextMeshProUGUI _coinsText;
    public override void AddListeners()
    {
        _playButton.onClick.AddListener(StartLevel);
    }

    public override void RemoveListeners()
    {
        _playButton.onClick.RemoveListener(StartLevel);
    }

    public override void Init()
    {
        _levelCountText.text = MainMenu.Instance.GetCurrentLevel();
        _scoreWoodenChest.text = MainMenu.Instance.GetScoreWoodenChest();
        _scoreGoldenChest.text = MainMenu.Instance.GetScoreGoldenChest();
    }

    private void Update()
    {
        _coinsText.text = MainMenu.Instance.GetUserCoinsCount();
    }

    private void StartLevel()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
