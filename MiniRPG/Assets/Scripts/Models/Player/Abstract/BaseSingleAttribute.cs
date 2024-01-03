
using System;
using UnityEngine;

public abstract class BaseSingleAttribute : ISingleAttribute
{
    #region Fields

    [SerializeField] protected float _value;
    
    // Property
    public float Value => _value;
    
    // Event
    // public event Action<float> OnValueChanged;

    #endregion



    #region Constructor

    protected BaseSingleAttribute(float setValue)
    {
        _value = setValue;
    }

    #endregion



    #region Interface Methods

    public void SetValue(float amount)
    {
        if (!CheckNegativeNumber(amount)) return;

        PerformSetting(amount);
    }

    public void AddValue(float amount)
    {
        if (!CheckNegativeNumber(amount)) return;
        
        PerformAddition(amount);
    }

    public void SubValue(float amount)
    {
        if (!CheckNegativeNumber(amount)) return;
        
        PerformSubtraction(amount);
    }

    #endregion
    
    
    
    // Abstract
    protected abstract void PerformSetting(float amount);
    protected abstract void PerformAddition(float amount);
    protected abstract void PerformSubtraction(float amount);



    #region Sub Methods

    public void AddPercentageValue(float percentage)
    {
        var addAmount = Value * (percentage / 100f);

        AddValue(addAmount);
    }

    public void SubPercentageValue(float percentage)
    {
        var subAmount = Value * (percentage / 100f);

        SubValue(subAmount);
    }

    private bool CheckNegativeNumber(float value)
    {
        if (!(value < 0)) return true;
        
        // Debug는 빌드 이전 전부 삭제해야 됌
        Debug.LogWarning("Amount is negative : " + value);
        return false;
    }

    protected void ValueChangedHandle(float newValue)
    {
        if (Mathf.Approximately(_value, newValue)) return;

        _value = newValue;
        // OnValueChanged?.Invoke(_value);
    }

    #endregion
}
