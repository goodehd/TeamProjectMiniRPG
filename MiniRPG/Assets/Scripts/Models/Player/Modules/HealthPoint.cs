
using UnityEngine;

public class HealthPoint : IStatus
{
    #region Fields

    [SerializeField] private float _currentValue;
    [SerializeField] private float _maxValue;
    
    // Properties
    public float CurrentValue => _currentValue;
    public float MaxValue => _maxValue;

    #endregion



    #region Constructor

    public HealthPoint(float setValue)
    {
        _maxValue = setValue;
        _currentValue = MaxValue;
    }

    public HealthPoint(float curValue, float maxValue)
    {
        _currentValue = curValue;
        _maxValue = maxValue;
    }

    #endregion



    #region Interface Methods

    public void AddValue(float amount)
    {
        // 현재 값에 amount를 추가 하되, 최대 값을 초과하지 않는다.
        _currentValue = Mathf.Min(CurrentValue + amount, MaxValue);
    }

    public void SubValue(float amount)
    {
        // 현재 값에 amount를 차감 하되, 0보다 작아지지 않는다.
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
        // 현재 값과 최대 값의 비율 계산
        return MaxValue > 0 ? CurrentValue / MaxValue : 0;
    }

    #endregion
}
