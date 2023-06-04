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
        CheckScoreWoodenChest();
        CheckScoreGoldenChest();
        
        if(deletePlayerPrefs)
            PlayerPrefs.DeleteAll();
        
        if(!PlayerPrefs.HasKey("level"))
            PlayerPrefs.SetInt("level",1);
        
        if(!PlayerPrefs.HasKey("coins"))
            PlayerPrefs.SetInt("coins",0);
    }

    public string GetCurrentLevel()
    {
        return PlayerPrefs.GetInt("level").ToString() + " level";
    }
    
    public string GetScoreWoodenChest()
    {
        return PlayerPrefs.GetInt("score") + "/5000";
    }
    
    public string GetScoreGoldenChest()
    {
        return PlayerPrefs.GetInt("level") + "/" + PlayerPrefs.GetInt("NextGoldenChest");
    }

    private void CheckScoreWoodenChest()
    {
        if (!PlayerPrefs.HasKey("score"))
            PlayerPrefs.SetInt("score",0);
        else
        {
            int score = PlayerPrefs.GetInt("score");
            if(score >= 5000)
            {
                score = 0;
                PlayerPrefs.SetInt("score",score);
                OpenWoodenChest();
            }
        }
    }
    
    private void CheckScoreGoldenChest()
    {
        if(!PlayerPrefs.HasKey("NextGoldenChest"))
            PlayerPrefs.SetInt("NextGoldenChest",5);
        else
        {
            int level = PlayerPrefs.GetInt("level");
            int nextGoldenChest = PlayerPrefs.GetInt("NextGoldenChest");
            if(level >= nextGoldenChest)
            {
                PlayerPrefs.SetInt("NextGoldenChest",nextGoldenChest+5);
                OpenGoldenChest();
            }
        }
    }

    private void OpenWoodenChest()
    {
        Debug.Log("OpenWoodenChest");
        UserBalanceSystem.Instance.AddCoins(100);
    }
    
    private void OpenGoldenChest()
    {
        Debug.Log("OpenGoldenChest");
        UserBalanceSystem.Instance.AddCoins(50);
    }

    public string GetUserCoinsCount()
    {
        return UserBalanceSystem.Instance.GetUserCoinsCount().ToString();
    }
}
