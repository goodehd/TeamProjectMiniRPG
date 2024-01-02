
using UnityEngine;

public class ExperiencePoint : IStatus
{
    #region Properties

    public float CurrentValue { get; set; }
    public float MaxValue { get; set; }

    #endregion



    #region Constructor

    public ExperiencePoint(float setValue)
    {
        MaxValue = setValue;
        CurrentValue = MaxValue;
    }

    public ExperiencePoint(float curValue, float maxValue)
    {
        CurrentValue = curValue;
        MaxValue = maxValue;
    }

    #endregion



    #region Interface Methods

    public void AddValue(float amount)
    {
        CurrentValue = Mathf.Min(CurrentValue + amount, MaxValue);
    }

    public void SubValue(float amount)
    {
        CurrentValue = Mathf.Max(CurrentValue - amount, 0f);
    }

    public float GetPercentage()
    {
        return MaxValue > 0 ? CurrentValue / MaxValue : 0;
    }

    #endregion
}