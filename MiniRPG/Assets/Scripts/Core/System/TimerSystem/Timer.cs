
using System;

public abstract class Timer
{
    #region Fields

    protected float _initialTime;
    
    // Properties
    protected float Time { get; set; }
    public bool IsRunning { get; protected set; }
    public float Progress => Time / _initialTime;

    // Events
    public event Action OnTimerStart;
    public event Action OnTimerStop;

    #endregion

    // Constructor
    protected Timer(float initTimeSeconds)
    {
        _initialTime = initTimeSeconds;
        IsRunning = false;
    }

    public void Start()
    {
        Time = _initialTime;
        
        if (IsRunning) return;
        
        IsRunning = true;
        OnTimerStart?.Invoke();
    }

    public void Stop()
    {
        if (!IsRunning) return;
        
        IsRunning = false;
        OnTimerStop?.Invoke();
    }

    public void Resume() => IsRunning = true;
    public void Pause() => IsRunning = false;

    public abstract void Tick(float deltaTime);
}
