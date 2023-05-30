using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Runtime;
using UnityEngine;

public class LevelLoaderSystem : MonoBehaviour
{
    [SerializeField] private List<PaoLevelObject> _listOfLevels;

    public int _currentLevelId;

    private PaoLevelObject _currentLevelObject;

    private void Start()
    {
        _currentLevelObject = GetCurrentLevel();
        SpawnObjects.Instance.StartSpawnObjects(_currentLevelObject);
        TimerSystem.Instance.StartTimer(TimeSpan.FromSeconds(_currentLevelObject.Timer));
    }

    private PaoLevelObject GetCurrentLevel()
    {
        foreach (var level in _listOfLevels)
        {
            if(level.Id == _currentLevelId)
                return level;
        }

        return null;
    }
    
}
