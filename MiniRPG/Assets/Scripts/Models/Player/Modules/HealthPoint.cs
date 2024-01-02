
using UnityEngine;

[System.Serializable]
public class HealthPoint : IStatus
{
    #region Properties

    public float CurrentValue { get; set; }
    public float MaxValue { get; set; }

    #endregion



    #region Constructor

    public HealthPoint(float setValue)
    {
        MaxValue = setValue;
        CurrentValue = MaxValue;
    }

    #endregion



    #region Interface Methods

    public void AddValue(float amount)
    {
        // 현재 값에 amount를 추가 하되, 최대 값을 초과하지 않는다.
        CurrentValue = Mathf.Min(CurrentValue + amount, MaxValue);
    }

    public void SubValue(float amount)
    {
        // 현재 값에 amount를 차감 하되, 0보다 작아지지 않는다.
        CurrentValue = Mathf.Max(CurrentValue - amount, 0f);
    }

    public float GetPercentage()
    {
        // 현재 값과 최대 값의 비율 계산
        return MaxValue > 0 ? CurrentValue / MaxValue : 0;
    }

    #endregion
}
