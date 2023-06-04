using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FullInventoryUI : UIElement
{
    [SerializeField] private Button _cleanInventoryButton;
    [SerializeField] private Button _leaveLevelButton;
    
    public override void AddListeners()
    {
        _leaveLevelButton.onClick.AddListener(LeaveLevel);
        _cleanInventoryButton.onClick.AddListener(CleanInventoryButton);
    }

    public override void RemoveListeners()
    {
        _leaveLevelButton.onClick.RemoveListener(LeaveLevel);
        _cleanInventoryButton.onClick.RemoveListener(CleanInventoryButton);
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

    private void CleanInventoryButton()
    {
        
    }
}
