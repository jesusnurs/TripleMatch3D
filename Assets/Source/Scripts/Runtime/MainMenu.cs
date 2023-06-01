using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance { get; set; }
    
    [SerializeField] private bool deletePlayerPrefs = false;
    
    private void Awake()
    {
        if(Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        if(!PlayerPrefs.HasKey("score"))
            PlayerPrefs.SetInt("score",0);
        
        if(deletePlayerPrefs)
            PlayerPrefs.DeleteAll();
        
        if(!PlayerPrefs.HasKey("level"))
            PlayerPrefs.SetInt("level",1);
        
    }

    public string GetCurrentLevel()
    {
        return PlayerPrefs.GetInt("level").ToString() + " level";
    }
    
    public string GetCurrentScore()
    {
        return PlayerPrefs.GetInt("score").ToString() + "/1000";
    }
}
