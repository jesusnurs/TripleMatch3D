using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoreHealthUI : UIElement
{
    [SerializeField] private Button _closeButton;
    [SerializeField] private Button _buyButton;
    public override void AddListeners()
    {
        _closeButton.onClick.AddListener(CloseWindow);
        _buyButton.onClick.AddListener(BuyHearts);
    }

    public override void RemoveListeners()
    {
        _closeButton.onClick.RemoveListener(CloseWindow);
        _buyButton.onClick.RemoveListener(BuyHearts);
    }

    public override void Init()
    {
        
    }
    
    private void CloseWindow()
    {
        UISystem.Instance.CloseCurrentWindow();
    }

    private void BuyHearts()
    {
        if (UserBalanceSystem.Instance.BuySomething(25))
        {
            UserHeartsSystem.Instance.AddHearts(10);
            UISystem.Instance.CloseCurrentWindow();
        }
        else
        {
            Debug.Log("Not enough coins");
            UISystem.Instance.CloseCurrentWindow();
        }
    }
}