
public interface ISingleAttribute
{
    #region Fields

    float Value { get; }

    #endregion



    #region Methods

    // amount가 음수 값일 수 없음.
    void AddValue(float amount);
    
    // amount가 음수 값일 수 없음. Value가 0보다 작아질 수 없음
    void SubValue(float amount);

    // Percentage 방식
    void AddPercentageValue(float percentage);
    void SubPercentageValue(float percentage);

    #endregion
}
