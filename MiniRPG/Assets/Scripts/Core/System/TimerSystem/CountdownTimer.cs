
public class CountdownTimer : Timer
{
    public CountdownTimer(float initTimeSeconds) : base(initTimeSeconds) { }

    public override void Tick(float deltaTime)
    {
        if (IsRunning && Time > Literals.ZeroF)
        {
            Time -= deltaTime;
        }

        if (IsRunning && Time <= Literals.ZeroF)
        {
            Stop();
        }
    }

    public bool IsFinished => Time <= Literals.ZeroF;
    public void Reset() => Time = _initialTime;

    public void Reset(float newTime)
    {
        _initialTime = newTime;
        Reset();
    }
}
