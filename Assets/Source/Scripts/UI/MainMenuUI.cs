using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : UIElement
{
    [SerializeField] private Button _playButton;

    [SerializeField] private TextMeshProUGUI _levelCountText;
    [SerializeField] private TextMeshProUGUI _scoreToOpenChest;
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
        _scoreToOpenChest.text = MainMenu.Instance.GetCurrentScore();
    }

    private void StartLevel()
    {
        SceneManager.LoadScene("LevelScene");
    }
}
