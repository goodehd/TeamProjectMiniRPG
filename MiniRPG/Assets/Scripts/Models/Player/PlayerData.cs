
/// <summary>
/// # PlayerData => Model (Data) 부분
/// </summary>
[System.Serializable]
public class PlayerData
{
    #region Fields

    // Status
    public HealthPoint Hp { get; private set; }
    public ManaPoint Mp { get; private set; }
    public ExperiencePoint Exp { get; private set; }
    
    // Singly Attributes
    public BaseDamage BaseDmg { get; private set; }
    public BaseDefense BaseDef { get; private set; }
    public FinalDamage FinalDmg { get; private set; }
    public FinalDefense FinalDef { get; private set; }
    public CriticalChance CritChance { get; private set; }
    public CriticalDamage CritDamage { get; private set; }
    public MoveSpeed MoveSpd { get; private set; }
    
    #endregion
    
    
    
    #region Constructor

    public PlayerData()
    {
        Initialize();
    }

    public PlayerData(float hp, float maxHp, float mp, float maxMp, float exp, float maxExp, 
        float baseDmg, float baseDef, float finalDmg, float finalDef,
        float critChance, float critDamage, float moveSpd)
    {
        Initialize(hp, maxHp, mp, maxMp, exp, maxExp, baseDmg, baseDef, finalDmg, finalDef,
            critChance, critDamage, moveSpd);
    }

    #endregion



    #region Initialize

    private void Initialize()
    {
        // 초기 세팅 값
        Hp = new HealthPoint(1000f, 1000f);
        Mp = new ManaPoint(200f, 200f);
        Exp = new ExperiencePoint(0f, 1000f);

        BaseDmg = new BaseDamage(50f);
        BaseDef = new BaseDefense(5f);
        FinalDmg = new FinalDamage(BaseDmg.Value);
        FinalDef = new FinalDefense(BaseDef.Value);
        CritChance = new CriticalChance(5f);
        CritDamage = new CriticalDamage(50f);
        MoveSpd = new MoveSpeed(5f);
    }
    
    // 로드된 데이터로 초기화
    private void Initialize(float hp, float maxHp, float mp, float maxMp, float exp, float maxExp, 
        float baseDmg, float baseDef, float finalDmg, float finalDef,
        float critChance, float critDamage, float moveSpd)
    {
        Hp = new HealthPoint(hp, maxHp);
        Mp = new ManaPoint(mp, maxMp);
        Exp = new ExperiencePoint(exp, maxExp);

        BaseDmg = new BaseDamage(baseDmg);
        BaseDef = new BaseDefense(baseDef);
        FinalDmg = new FinalDamage(finalDmg);
        FinalDef = new FinalDefense(finalDef);
        CritChance = new CriticalChance(critChance);
        CritDamage = new CriticalDamage(critDamage);
        MoveSpd = new MoveSpeed(moveSpd);
    }

    #endregion
}