using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelObjectsCounter : MonoBehaviour
{
    public static LevelObjectsCounter Instance;
    
    private List<PaoSelectableObject> _listOfAllObjects;

    private bool IsPlaying = true;
    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        GameStateCallBacks.Instance.OnGameWon += OnAllObjectsSelected;
    }

    private void FixedUpdate()
    {
        CheckObjectsInBox();
    }

    public void CheckObjectsInBox()
    {
        if (_listOfAllObjects != null && IsPlaying)
        {
            foreach (var obj in _listOfAllObjects)
            {
                if(obj != null)
                    return;
            }
            IsPlaying = false;
            GameStateCallBacks.Instance.OnGameWon();
        }
    }
    public void SetAllObjects(List<PaoSelectableObject> objs)
    {
        _listOfAllObjects = objs;
    }

    public void OnAllObjectsSelected()
    {
        UISystem.Instance.OpenWindow("Win");
    }
}
