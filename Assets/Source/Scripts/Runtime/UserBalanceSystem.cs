using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserBalanceSystem : MonoBehaviour
{
    public static UserBalanceSystem Instance;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public int GetUserCoinsCount()
    {
        return PlayerPrefs.GetInt("coins");
    }

    public void AddCoins(int count)
    {
        int currentCoins = GetUserCoinsCount() + count;
        PlayerPrefs.SetInt("coins",currentCoins);
    }
    public bool BuySomething(int cost)
    {
        int currentCoins = GetUserCoinsCount();
        
        if (currentCoins < cost)
            return false;

        currentCoins -= cost;
        PlayerPrefs.SetInt("coins",currentCoins);
        return true;
    }
}
