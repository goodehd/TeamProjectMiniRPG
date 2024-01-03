
using UnityEngine;

public class FinalDefense : BaseSingleAttribute
{
    // Constructor
    public FinalDefense(float setValue) : base(setValue) { }

    
    
    #region Abstract Methods

    protected override void PerformSetting(float amount)
    {
        // 최소치 ~ 최대치 예외 및 검증
        amount = Mathf.Clamp(amount, Literals.DEF_MIN, Literals.DEF_MAX);
        
        ValueChangedHandle(amount);
    }

    protected override void PerformAddition(float amount)
    {
        var newValue = Mathf.Min(_value + amount, Literals.DEF_MAX);
        
        ValueChangedHandle(newValue);
    }

    protected override void PerformSubtraction(float amount)
    {
        var newValue = Mathf.Max(_value - amount, Literals.DEF_MIN);
        
        ValueChangedHandle(newValue);
    }

    #endregion
}
