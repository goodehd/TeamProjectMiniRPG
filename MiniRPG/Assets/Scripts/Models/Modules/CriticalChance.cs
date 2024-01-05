using UnityEngine;

public class CriticalChance : BaseSingleAttribute
{
    // Constructor
    public CriticalChance(float setValue) : base(setValue) { }

    
    
    #region Abstract Methods

    protected override void PerformSetting(float amount)
    {
        // 최소치 ~ 최대치 예외 및 검증
        amount = Mathf.Clamp(amount, Literals.CRIT_CHANCE_MIN, Literals.CRIT_CHANCE_MAX);
        
        ValueChangedHandle(amount);
    }

    protected override void PerformAddition(float amount)
    {
        var newValue = Mathf.Min(_value + amount, Literals.CRIT_CHANCE_MAX);
        
        ValueChangedHandle(newValue);
    }

    protected override void PerformSubtraction(float amount)
    {
        var newValue = Mathf.Max(_value - amount, Literals.CRIT_CHANCE_MIN);
        
        ValueChangedHandle(newValue);
    }

    #endregion
}