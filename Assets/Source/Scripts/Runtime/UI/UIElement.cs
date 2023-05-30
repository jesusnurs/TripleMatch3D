using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UIElement : MonoBehaviour
{
    protected UISystem UISystem => UISystem.Instance;
    //protected IAudioSystem audioSystem => AudioSystem.Instance;
        
    [SerializeField]
    protected List<UIElement> children;

    [SerializeField]
    private float destroyDelay = 0.5f;
    [SerializeField]
    private float closeDelay = 0.5f;
    public Action OnOpen { get; set; }
    public Action OnClose { get; set; }
    public Action OnDestroy { get; set; }

        
    /// <summary>
    /// Method reserved for adding button listeners, executed on open 
    /// </summary>
    public abstract void AddListeners();
        
    /// <summary>
    /// Method reserved for removing button listeners, executed on close 
    /// </summary>
    public abstract void RemoveListeners();

    /// <summary>
    /// Base Init method, executed before AddListeners 
    /// </summary>
    public abstract void Init();
    public virtual void Open()
    {
        AddListeners();
        OnOpen?.Invoke();
        gameObject.SetActive(true);
    }

    public void OpenWithChildren()
    {
        Open();

        foreach (var child in children)
        {
            child.Open();
        }
    }

    public virtual void Close()
    {
        RemoveListeners();
        OnClose?.Invoke();
        Invoke(nameof(Deactivate), closeDelay);
    }
    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
    public virtual void Destroy()
    {
        RemoveListeners();
        OnDestroy?.Invoke();
        Destroy(gameObject, destroyDelay);
    }
        
    public void GoToPreviousWindow()
    {
        UISystem.CloseCurrentWindow();
    }
}
