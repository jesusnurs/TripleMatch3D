using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : UIElement
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _homeButton;
    public override void AddListeners()
    {
        _closeButton.onClick.AddListener(CloseWindow);
        _homeButton.onClick.AddListener(BackHome);
    }

    public override void RemoveListeners()
    {
        _closeButton.onClick.RemoveListener(CloseWindow);
        _homeButton.onClick.RemoveListener(BackHome);
    }

    public override void Init()
    {
        
    }
    
    private void CloseWindow()
    {
        UISystem.Instance.CloseCurrentWindow();
        TimerSystem.Instance.ResumeTimer();
    }

    private void BackHome()
    {
        SceneManager.LoadScene("MainMenu");
    }
}