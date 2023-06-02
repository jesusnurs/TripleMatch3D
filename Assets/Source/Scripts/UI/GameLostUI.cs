using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameLostUI : UIElement
{
    [SerializeField] private Button _retryButton;
    [SerializeField] private Button _homeButton;
    public override void AddListeners()
    {
        _retryButton.onClick.AddListener(RetryLevel);
        _homeButton.onClick.AddListener(BackHome);
    }

    public override void RemoveListeners()
    {
        _retryButton.onClick.RemoveListener(RetryLevel);
        _homeButton.onClick.RemoveListener(BackHome);
    }

    public override void Init()
    {
        
    }

    private void RetryLevel()
    {
        SceneManager.LoadScene("LevelScene");
        UISystem.Instance.CloseCurrentWindow();
    }

    private void BackHome()
    {
        SceneManager.LoadScene("MainMenu");
        UISystem.Instance.CloseCurrentWindow();
    }
}
