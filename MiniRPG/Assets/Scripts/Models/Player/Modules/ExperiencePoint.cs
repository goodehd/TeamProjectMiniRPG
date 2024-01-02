
using UnityEngine;

public class ExperiencePoint : IStatus
{
    #region Fields

    [SerializeField] private float _currentValue;
    [SerializeField] private float _maxValue;
    
    // Properties
    public float CurrentValue => _currentValue;
    public float MaxValue => _maxValue;

    #endregion



    #region Constructor

    public ExperiencePoint(float setValue)
    {
        _maxValue = setValue;
        _currentValue = MaxValue;
    }

    public ExperiencePoint(float curValue, float maxValue)
    {
        _currentValue = curValue;
        _maxValue = maxValue;
    }

    #endregion



    #region Interface Methods

    public void AddValue(float amount)
    {
        _currentValue = Mathf.Min(CurrentValue + amount, MaxValue);
    }

    public void SubValue(float amount)
    {
        _currentValue = Mathf.Max(CurrentValue - amount, 0f);
    }
    
    public void AddPercentageValue(float percentage)
    {
        var addAmount = MaxValue * (percentage / 100f);

        AddValue(addAmount);
    }
    
    public void SubPercentageValue(float percentage)
    {
        var subAmount = MaxValue * (percentage / 100f);

        SubValue(subAmount);
    }

    public float GetPercentage()
    {
        return MaxValue > 0 ? CurrentValue / MaxValue : 0;
    }

    #endregion
}