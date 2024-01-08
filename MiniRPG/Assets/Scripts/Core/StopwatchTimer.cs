
public class StopwatchTimer : Timer
{
    public StopwatchTimer(float initTimeSeconds) : base(initTimeSeconds) { }

    public override void Tick(float deltaTime)
    {
        if (IsRunning)
        {
            Time += deltaTime;
        }
    }

    public void Reset() => Time = Literals.ZeroF;
    public float GetTime() => Time;
}
