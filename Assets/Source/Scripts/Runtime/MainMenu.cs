using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public static MainMenu Instance { get; set; }
    
    
    private void Awake()
    {
        if(Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        if(!PlayerPrefs.HasKey("level"))
            PlayerPrefs.SetInt("level",1);
    }

    public string GetCurrentLevel()
    {
        return PlayerPrefs.GetInt("level").ToString() + " level";
    }
}
