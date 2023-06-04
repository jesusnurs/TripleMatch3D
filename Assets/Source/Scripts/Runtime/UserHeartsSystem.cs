using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserHeartsSystem : MonoBehaviour
{
    public static UserHeartsSystem Instance;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public int GetLeftHearts()
    {
        return PlayerPrefs.GetInt("hearts");
    }

    public void AddHearts(int count)
    {
        int currentHearts = GetLeftHearts() + count;
        PlayerPrefs.SetInt("hearts",currentHearts);
    }
    
    public bool RemoveHeart()
    {
        int currentHearts = GetLeftHearts();

        if (currentHearts > 0)
        {
            PlayerPrefs.SetInt("hearts",currentHearts-1);
            return true;
        }
        else
        {
            Debug.Log("Not enough hearts");
            return false;
        }
    }
}
