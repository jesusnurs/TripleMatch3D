using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    public static UISystem Instance { get; set; }

    [SerializeField] private Transform _UIFolder;
    [SerializeField] private string _defaultWindow;
    
    [SerializeField] private List<UIElement> windows;
    private Dictionary<string, UIElement> windowDictionary;
    
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

    private void Start()
    {
        foreach (var window in windows)
        {
            windowDictionary = windows.ToDictionary(x => x.Name, x => x);
        }
        if(_defaultWindow != "")
            OpenWindow(_defaultWindow);
    }

    //Open new window with closing previous
    public void OpenWindow(string windowName)
    {
        if(_currentWindow != null)
            _currentWindow.Close();
        
        var window = Instantiate(windowDictionary[windowName],_UIFolder).GetComponent<UIElement>();
        //window.gameObject.transform.SetParent(_UIFolder);
        
        windowStack.Push(window);
        window.Open();

        _currentWindow = window;
    }
    
    //Don't close previous window, just open new window above previous
    public void OpenAboveWindow(string windowName)
    {
        windowStack.Peek().RemoveListeners();
        var window = Instantiate(windowDictionary[windowName],_UIFolder).GetComponent<UIElement>();
        //window.gameObject.transform.SetParent(_UIFolder);
        
        windowStack.Push(window);
        window.Open();

        _currentWindow = window;
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
        closeWindow.Destroy();
        
        if (windowStack.Count > 0)
        {
            _currentWindow = windowStack.Peek();
            _currentWindow.Open();
        }
    }
}
