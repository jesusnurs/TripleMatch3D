using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameWinUI : UIElement
{
    [SerializeField] private Button _homeButton;
    public override void AddListeners()
    {
        _homeButton.onClick.AddListener(BackHome);
    }

    public override void RemoveListeners()
    {
        _homeButton.onClick.RemoveListener(BackHome);
    }

    public override void Init()
    {
        throw new System.NotImplementedException();
    }
    

    private void BackHome()
    {
        SceneManager.LoadScene("MainMenu");
        UISystem.Instance.CloseCurrentWindow();
    }
}