using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UISystem : MonoBehaviour
{
    public static UISystem Instance { get; set; }

    //[SerializeField] private List<UIWindow3> windows;
    //private Dictionary<string, UIWindow3> windowDictionary;
    
    private Stack<UIElement> windowStack;
    private List<string>  openWindowNames = new List<string>();
    
    
    private void Awake()
    {
        if(Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void OpenWindow(UIElement prefab)
    {
        
    }
    
    private void CloseWindow(UIElement prefab)
    {
        
    }

    public UIElement CloseCurrentWindow()
    {
        if (windowStack.Count > 0)
        {
            var window = windowStack.Pop();
            openWindowNames.Remove(window.name);
            window.Destroy();
            if (windowStack.Count > 0)
            {
                windowStack.Peek().OpenWithChildren();
            }
            return window;
        }
        else
        {
            Debug.LogError("No window open");
            return null;
        }
    }
}
