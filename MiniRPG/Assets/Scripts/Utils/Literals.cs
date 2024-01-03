
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

    #region Path

    public const string CSV_PATH = "Assets/@Resources/Csv/";
    public const string JSON_PATH = "Assets/@Resources/Json/";

    #endregion
}
