
/// <summary>
/// # 리터럴즈 (상수형 데이터)
/// - 사용 시 다음을 준수해주세요.
/// - 자신과 관련된 리전(Region)이 없다면 꼭 만들어서 사용하세요.
///
/// ex)
///   #region Enemy Names
///   public const string ENEMY_CREATURE_01 = "버섯 꽁이";...
///   #endregion
/// </summary>
public static class Literals
{
    public const string INTRO_SPRITE = "IntroSprite";
    public const string INTRO_STARTBTN = "StartBtn;";
    public const string INTRO_STARTBTN_TEXT = "StartText";

    #region Base Single Attribute

    // Damage
    public const float DMG_MIN = 0f;
    public const float DMG_MAX = 999999f;

    // Defense 
    public const float DEF_MIN = 0f;
    public const float DEF_MAX = 999999f;

    // Critical
    public const float CRIT_CHANCE_MIN = 0f;
    public const float CRIT_CHANCE_MAX = 100f;
    public const float CRIT_DMG_MIN = 0f;
    public const float CRIT_DMG_MAX = 10000f;

    #endregion



    #region Base Status

    public const float HP_MIN = 0f;
    public const float HP_MAX = 999999f;

    public const float MP_MIN = 0f;
    public const float MP_MAX = 999999f;

    public const float EXP_MIN = 0f;
    public const float EXP_MAX = 999999999f;

    #endregion
}
