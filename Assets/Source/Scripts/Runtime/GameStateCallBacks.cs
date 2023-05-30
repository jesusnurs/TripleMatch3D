using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateCallBacks : MonoBehaviour
{
    public static GameStateCallBacks Instance { get; private set; }
    
    public Action OnGameWon;
    public Action OnGameLost;
    

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }
}
