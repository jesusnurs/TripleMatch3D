using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem1 : MonoBehaviour
{
    public static UISystem1 Instance { get; set; }

    [SerializeField] private GameObject _timerFinishedUI;
    
    
    private Stack<UIElement> windowStack = new Stack<UIElement>();
    private List<string>  openWindowNames = new List<string>();

    private UIElement _currentWindow;
    
    
    private void Awake()
    {
        if(Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void OpenWindow(UIElement prefab)
    {
        if(_currentWindow != null)
            _currentWindow.Close();
            
        windowStack.Push(prefab);
        prefab.Open();

        _currentWindow = prefab;
    }
    
    /*
    private void CloseWindow(UIElement prefab)
    {
        windowStack.Pop();
        prefab.gameObject.SetActive(true);
    }
    */

    public void CloseCurrentWindow()
    {
        var closeWindow = windowStack.Pop();
        closeWindow.Close();
        _currentWindow = windowStack.Peek();
        
        if(_currentWindow != null)
            _currentWindow.Open();
    }
}