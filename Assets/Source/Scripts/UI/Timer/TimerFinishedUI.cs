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
        timeFreezerButton.AddListener(OnTimeFreezerButton);
        timeFreezerButtonClose.AddListener(TimeFreezerClose);
        timeFreezerButtonBackGroundClose.AddListener(TimeFreezerClose);
    }

    public override void RemoveListeners()
    {
        timeFreezerButton.RemoveListener(OnTimeFreezerButton);
        timeFreezerButtonClose.RemoveListener(TimeFreezerClose);
        timeFreezerButtonBackGroundClose.RemoveListener(TimeFreezerClose);
    }

    public override void Init()
    {
        var level = paoLevelProvider.CurrentLevel;
        taskListDrawer.SetNewCollection(new ObservableCollection<object>(level.LevelTasks));
        taskListDrawer.ForceRebuild();
    }
    private void OnTimeFreezerButton()
    {
        timeFreezerSystem.AddTime();
        timeFreezerSystem.LastChanceUsed = true;
        UISystem.CloseCurrentWindow();
    }

    private void TimeFreezerClose()
    {
        //UISystem.CloseCurrentWindow();
        timeFreezerSystem.CancelLastChance();
    }
}
