
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
    public const float ZeroF = 0f;
    
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



    #region Path

    public const string CSV_PATH = "Assets/@Resources/Csv/";
    public const string JSON_PATH = "Assets/@Resources/Json/";

    #endregion



    #region Layer

    public const string LAYER_MASK_WALKABLE = "Walkable";

    #endregion

    #region UI_Intro
    public const string INTRO_BUTTON = "IntroBtn";
    #endregion

    #region UI_SelectScene
    public const string SELECT_CANVAS = "Select_UI";

    public const string SELECT_MALE_BUTTON = "Male_Select";
    public const string SELECT_FEMALE_BUTTON = "Female_Select";
    public const string SELECT_START_BUTTON = "StartBtn";

    public const string SELECT_MALE_JOB_TEXT = "Male_JobText";
    public const string SELECT_MALE_LV_TEXT = "Male_LvText";
    public const string SELECT_FEMALE_JOB_TEXT = "Female_JobText";
    public const string SELECT_FEMALE_LV_TEXT = "Female_LvText";
    #endregion

    #region UI_Inventory
    public const string ITEMSLOT_ITEMSLOT_BUTTON = "ItemSlotUI";
    public const string ITEMSLOT_ITEMICON_TRANSFORM = "ItemIcon";
    public const string ITEMSLOT_EQUIPMARK_TRANSFORM = "EquipMark";

    public const string INVENTORY_INVENTORY_TRANSFORM = "Inventory";
    public const string INVENTORY_EXIT_BUTTON = "ExitBtn";

    #endregion

    #region ViliagePrefabsName
    public static string[] ViliagePrefabNames =
    {
        "Buildings",
        "Path",
        "Props",
        "Rocks",
        "Sky",
        "Terrain",
        "Vegetation"
    };

    public static string[] ViliageNPCNames =
    {
        "DungeonNPC",
        "QuestNPC",
        "ShopNPC",
    };

    #endregion
}
