using UnityEngine;

public class MoveSpeed : ISingleAttribute
{
    #region Field

    [SerializeField] private float _value;
    
    // Properties
    public float Value => _value;

    #endregion



    #region Constructor

    public MoveSpeed(float setValue)
    {
        _value = setValue;
    }

    #endregion



    #region Interface Methods

    public void AddValue(float amount)
    {
        if (amount < 0)
        {
            // Debug는 빌드 시 다 삭제해야 됌
            Debug.LogWarning("Amount is negative" + amount);
            return;
        }

        // 나중에 최대 속도 제한 값은 정해줘야 됌
        _value += Mathf.Min(Value + amount, 999f);
    }

    public void SubValue(float amount)
    {
        if (amount < 0)
        {
            // Debug는 빌드 시 다 삭제해야 됌
            Debug.LogWarning("Amount is negative" + amount);
            return;
        }

        _value = Mathf.Max(Value - amount, 0f);
    }
    
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

    #endregion
}