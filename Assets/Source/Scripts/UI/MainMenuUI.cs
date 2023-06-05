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
    [SerializeField] private Button _addCoinsButton;
    [SerializeField] private Button _addHeartsButton;
    [SerializeField] private Button _settingsButton;

    [SerializeField] private TextMeshProUGUI _levelCountText;
    [SerializeField] private TextMeshProUGUI _scoreWoodenChest;
    [SerializeField] private TextMeshProUGUI _scoreGoldenChest;
    [SerializeField] private TextMeshProUGUI _coinsText;
    [SerializeField] private TextMeshProUGUI _heartsText;
    public override void AddListeners()
    {
        _playButton.onClick.AddListener(StartLevel);
        _addHeartsButton.onClick.AddListener(AddHearts);
        _settingsButton.onClick.AddListener(OpenSettings);
    }

    public override void RemoveListeners()
    {
        _playButton.onClick.RemoveListener(StartLevel);
        _addHeartsButton.onClick.RemoveListener(AddHearts);
        _settingsButton.onClick.RemoveListener(OpenSettings);
    }

    public override void Init()
    {
        _levelCountText.text = MainMenu.Instance.GetCurrentLevel();
        _scoreWoodenChest.text = MainMenu.Instance.GetScoreWoodenChest();
        _scoreGoldenChest.text = MainMenu.Instance.GetScoreGoldenChest();
    }

    private void Update()
    {
        _heartsText.text = MainMenu.Instance.GetLeftHearts();
        _coinsText.text = MainMenu.Instance.GetUserCoinsCount();
    }

    private void StartLevel()
    {
        if(UserHeartsSystem.Instance.RemoveHeart())
            SceneManager.LoadScene("LevelScene");
    }

    private void AddHearts()
    {
        UISystem.Instance.OpenAboveWindow("MoreHealth");
    }

    private void OpenSettings()
    {
        UISystem.Instance.OpenAboveWindow("Settings");
    }
}
