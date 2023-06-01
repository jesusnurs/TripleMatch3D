using System;
using System.Collections;
using System.Collections.Generic;
using Data;
using Runtime;
using UnityEngine;

public class LevelLoaderSystem : MonoBehaviour
{
    public static LevelLoaderSystem Instance;
    
    [SerializeField] private List<PaoLevelObject> _listOfLevels;

    public int _currentLevelId;

    private PaoLevelObject _currentLevelObject;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }
    
    private void Start()
    {
        _currentLevelId = PlayerPrefs.GetInt("level") - 1;
        RunCurrentLevel();
        GameStateCallBacks.Instance.OnGameWon += IncreaseCurrentLevel;
    }

    public PaoLevelObject GetCurrentLevel()
    {
        foreach (var level in _listOfLevels)
        {
            if(level.Id == _currentLevelId)
                return level;
        }

        return null;
    }
    
    public void RunCurrentLevel()
    {
        _currentLevelObject = GetCurrentLevel();
        SpawnObjects.Instance.StartSpawnObjects(_currentLevelObject);
        TimerSystem.Instance.StartTimer(TimeSpan.FromSeconds(_currentLevelObject.Timer));
    }

    public void IncreaseCurrentLevel()
    {
        _currentLevelId++;
        PlayerPrefs.SetInt("level",_currentLevelId+1);
    }
}
