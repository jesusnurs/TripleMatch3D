using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerFinishedUI : UIElement
{
    [SerializeField] private Button _addTimeButton;
    [SerializeField] private Button _leaveLevelButton;

    [SerializeField] private int _addTimeCoinsCost;
    
    public override void AddListeners()
    {
        _leaveLevelButton.onClick.AddListener(LeaveLevel);
        _addTimeButton.onClick.AddListener(AddTime);
    }

    public override void RemoveListeners()
    {
        _leaveLevelButton.onClick.RemoveListener(LeaveLevel);
        _addTimeButton.onClick.RemoveListener(AddTime);
    }

    public override void Init()
    {
        
    }

    private void LeaveLevel()
    {
        UISystem.Instance.CloseCurrentWindow();
        UISystem.Instance.OpenWindow("Lost");
        GameStateCallBacks.Instance?.OnGameLost.Invoke();
    }

    private void AddTime()
    {
        if (UserBalanceSystem.Instance.BuySomething(_addTimeCoinsCost))
        {
            UISystem.Instance.CloseCurrentWindow();
            TimerSystem.Instance.AddTime(TimeSpan.FromSeconds(60));
            TimerSystem.Instance.ResumeTimer();
        }
        else 
            Debug.Log("Not enough coins");
    }
}
