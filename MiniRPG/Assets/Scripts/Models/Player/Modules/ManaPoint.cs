
using UnityEngine;

public class ManaPoint : BaseStatus
{
    #region Constructor

    public ManaPoint(float setValue) : base(setValue) { }

    public ManaPoint(float curValue, float maxValue) : base(curValue, maxValue) { }

    #endregion



    #region Abstract Methods

    protected override void PerformSetting(float amount)
    {
        // 최소치 ~ 최대치 예외 및 검증
        amount = Mathf.Clamp(amount, Literals.MP_MIN, _maxValue);
        
        ValueChangedHandle(amount, _maxValue);
    }

    protected override void PerformAddition(float amount)
    {
        var newCurValue = Mathf.Min(_curValue + amount, _maxValue);
        
        ValueChangedHandle(newCurValue, _maxValue);
    }

    protected override void PerformSubtraction(float amount)
    {
        var newCurValue = Mathf.Max(_curValue - amount, Literals.MP_MIN);

        ValueChangedHandle(newCurValue, _maxValue);
    }

    protected override void PerformMaxSetting(float amount)
    {
        amount = Mathf.Clamp(amount, _maxValue, Literals.MP_MAX);

        ValueChangedHandle(_curValue, amount);
    }

    protected override void PerformMaxAddition(float amount)
    {
        var newMaxValue = Mathf.Min(_maxValue + amount, Literals.MP_MAX);
        
        ValueChangedHandle(_curValue, newMaxValue);
    }

    protected override void PerformMaxSubtraction(float amount)
    {
        var newMaxValue = Mathf.Max(_maxValue - amount, 1f);
        
        ValueChangedHandle(_curValue, newMaxValue);
    }

    #endregion
}
