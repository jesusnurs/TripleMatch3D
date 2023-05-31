using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerFinishedUI : UIElement
{
    [SerializeField] private Button _addTimeButton;
    [SerializeField] private Button _leaveLevelButton;
    
    public override void AddListeners()
    {
        _leaveLevelButton.onClick.AddListener(LeaveLevel);
    }

    public override void RemoveListeners()
    {
        _leaveLevelButton.onClick.RemoveListener(LeaveLevel);
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
}
