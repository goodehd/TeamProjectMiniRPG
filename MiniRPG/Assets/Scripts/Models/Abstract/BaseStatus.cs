
using System;
using UnityEngine;

public abstract class BaseStatus : IStatus
{
    #region Fields

    [SerializeField] protected float _curValue;
    [SerializeField] protected float _maxValue;
    
    // Properties
    public float CurValue => _curValue;
    public float MaxValue => _maxValue;
    
    // Event
    // public event Action<float, float> OnValueChanged;

    #endregion
    
    
    
    #region Constructor

    protected BaseStatus(float setValue)
    {
        _maxValue = setValue;
        _curValue = _maxValue;
    }

    protected BaseStatus(float curValue, float maxValue)
    {
        _curValue = curValue;
        _maxValue = maxValue;
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

    public void SetMaxValue(float amount)
    {
        if (!CheckNegativeNumber(amount)) return;
        
        PerformMaxSetting(amount);
    }

    public void AddMaxValue(float amount)
    {
        if (!CheckNegativeNumber(amount)) return;
        
        PerformMaxAddition(amount);
    }

    public void SubMaxValue(float amount)
    {
        if (!CheckNegativeNumber(amount)) return;
        
        PerformMaxSubtraction(amount);
    }

    public float GetPercentage() => (MaxValue > 0f) ? CurValue / MaxValue : 0f;

    #endregion
    
    
    
    // Abstract
    protected abstract void PerformSetting(float amount);
    protected abstract void PerformAddition(float amount);
    protected abstract void PerformSubtraction(float amount);
    protected abstract void PerformMaxSetting(float amount);
    protected abstract void PerformMaxAddition(float amount);
    protected abstract void PerformMaxSubtraction(float amount);



    #region Sub Methods

    public void AddPercentageValue(float percentage)
    {
        AddValue(GetPercentageAmount(CurValue, percentage));
    }

    public void SubPercentageValue(float percentage)
    {
        SubValue(GetPercentageAmount(CurValue, percentage));
    }

    public void AddPercentageMaxValue(float percentage)
    {
        AddMaxValue(GetPercentageAmount(MaxValue, percentage));
    }

    public void SubPercentageMaxValue(float percentage)
    {
        SubMaxValue(GetPercentageAmount(MaxValue, percentage));
    }

    private bool CheckNegativeNumber(float value)
    {
        if (!(value < 0)) return true;
        
        // Debug는 빌드 이전 전부 삭제해야 됌
        Debug.LogWarning("Amount is negative : " + value);
        return false;
    }

    private float GetPercentageAmount(float value, float percentage)
        => value * (percentage / 100f);

    protected void ValueChangedHandle(float newCurValue, float newMaxValue)
    {
        var curValueChanged = !Mathf.Approximately(_curValue, newCurValue);
        var maxValueChanged = !Mathf.Approximately(_maxValue, newMaxValue);

        if (!curValueChanged && !maxValueChanged) return;
        
        _curValue = newCurValue;
        _maxValue = newMaxValue;
        Debug.Log(_curValue + " " + _maxValue);
        // OnValueChanged?.Invoke(_curValue, _maxValue);
    }

    #endregion
}
