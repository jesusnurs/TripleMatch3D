using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PaoTimerUI : MonoBehaviour
{
    
    [SerializeField] private TextMeshProUGUI timerText;

    private void Update()
    {
        //_timerText.text = _timerSystem.GetTime().Seconds.ToString();
        
        var time = TimerSystem.Instance.GetTime();

        if (time.TotalSeconds > 60)
        {
            timerText.text = $"{time.Minutes:00}:{time.Seconds:00}";
        }
        else
        {
            var mills = time.Milliseconds / 10;
            timerText.text = $"{time.Seconds:00}:{mills:00}";
            
        }
            
        if (time.TotalSeconds <= 0)
        {
            timerText.text = "00:00";
        }
    }
}
