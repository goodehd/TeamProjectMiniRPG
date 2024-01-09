
using System;

public interface IStatus
{
    #region Fields

    float CurValue { get; }
    float MaxValue { get; }
    
    // Event
    // event Action<float, float> OnValueChanged;

    #endregion
    
    
    
    #region Methods

    void SetValue(float amount);

    // Current Value + Amount = Max Value를 넘을 수 없음
    void AddValue(float amount);
    
    // Current Value - Amount = 최소치 (0)보다 아래로 내려갈 수 없음
    void SubValue(float amount);

    void SetMaxValue(float amount);
    void AddMaxValue(float amount);
    void SubMaxValue(float amount);
    
    // Max Value와 Current Value의 Ratio(Percentage)
    float GetPercentage();

    #endregion
} 