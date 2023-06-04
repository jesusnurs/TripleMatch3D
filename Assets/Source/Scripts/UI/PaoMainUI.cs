using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PaoMainUI : UIElement
{
    [SerializeField] private Button _pauseButton;
    public override void AddListeners()
    {
        _pauseButton.onClick.AddListener(OpenPauseWindow);
    }

    public override void RemoveListeners()
    {
        _pauseButton.onClick.RemoveListener(OpenPauseWindow);
    }

    public override void Init()
    {
        var list = gameObject.GetComponentsInChildren<Cell>();
        Inventory.Instance.SetListOfCells(list.ToList());
    }

    private void OpenPauseWindow()
    {
        SelectionSystem.Instance.DeactivateSelectionSystem();
        TimerSystem.Instance.PauseTimer();
        UISystem.Instance.OpenAboveWindow("Pause");
    }
}