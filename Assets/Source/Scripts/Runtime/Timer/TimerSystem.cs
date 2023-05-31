using System;
using System.Collections;
using System.Collections.Generic;
using Runtime;
using UnityEngine;

public class TimerSystem : MonoBehaviour
{
    public static TimerSystem Instance;
    
    private bool isRunning;
    [SerializeField]private float timeLeft;
    private float lazyTime;

    public void Init()
    {
        GameStateCallBacks.Instance.OnGameWon += StopTimer;
        GameStateCallBacks.Instance.OnGameLost += StopTimer;
        
        OnTimerFinished += OpenTimerFinishedUI;
    }

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        Init();
    }

    public Action OnPaused { get; set; }
    public Action OnResumed { get; set; }
    public Action OnTimerFinished { get; set; }

    public float CurrentSpeed { get; set; }

    public void StartTimer(TimeSpan timeSpan)
    {
        isRunning = true;
        CurrentSpeed = 1f;
        timeLeft = (float)timeSpan.TotalSeconds;
    }

    public void SetTime(TimeSpan timeSpan)  
    {
        timeLeft = (float)timeSpan.TotalSeconds;
    }

    public TimeSpan GetTime()
    {
        return TimeSpan.FromSeconds(timeLeft);
    }

    public void PauseTimer()
    {
        isRunning = false;
        OnPaused?.Invoke();
    }

    public void ResumeTimer()
    {
        isRunning = true;
        OnResumed?.Invoke();
    }

    public void StopTimer()
    {
        isRunning = false;
        timeLeft = 0;
    }

    public void AddTime(TimeSpan timeSpan)
    {
        timeLeft += (float)timeSpan.TotalSeconds;
    }

    public void SetSpeed(float speedMultiplier)
    {
        CurrentSpeed = speedMultiplier;
    }

    public TimeSpan GetLazyTime()
    {
        return TimeSpan.FromSeconds(lazyTime);
    }
    
    private void OpenTimerFinishedUI()
    {
        SelectionSystem.Instance.DeactivateSelectionSystem();
        UISystem.Instance.OpenWindow("TimerFinished");
    }
    private void Update()
    {
        if (!isRunning) return;

        lazyTime = timeLeft;
            
        timeLeft -= Time.deltaTime * CurrentSpeed;
            
        if (timeLeft <= 0)
        {
            StopTimer();
            OnTimerFinished?.Invoke();
        }
    }
}
