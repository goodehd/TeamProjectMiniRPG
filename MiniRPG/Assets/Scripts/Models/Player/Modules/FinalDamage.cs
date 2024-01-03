using UnityEngine;

public class FinalDamage : BaseSingleAttribute
{
    // Constructor
    public FinalDamage(float setValue) : base(setValue) { }

    
    
    #region Abstract Methods

    protected override void PerformSetting(float amount)
    {
        // 최소치 ~ 최대치 예외 및 검증
        amount = Mathf.Clamp(amount, Literals.DMG_MIN, Literals.DMG_MAX);
        
        ValueChangedHandle(amount);
    }

    protected override void PerformAddition(float amount)
    {
        var newValue = Mathf.Min(_value + amount, Literals.DMG_MAX);
        
        ValueChangedHandle(newValue);
    }

    protected override void PerformSubtraction(float amount)
    {
        var newValue = Mathf.Max(_value - amount, Literals.DMG_MIN);
        
        ValueChangedHandle(newValue);
    }

    #endregion
}