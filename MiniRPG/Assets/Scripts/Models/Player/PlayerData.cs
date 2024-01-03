using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// # PlayerData => Model (Data) 부분
/// </summary>
[System.Serializable]
public class PlayerData
{
    #region Fields

    // Status
    public HealthPoint HP { get; private set; }
    public ManaPoint MP { get; private set; }
    public ExperiencePoint EXP { get; private set; }
    
    // Singly Attributes
    public BaseDamage BaseDMG { get; private set; }
    public BaseDefense BaseDEF { get; private set; }
    public FinalDamage FinalDMG { get; private set; }
    public FinalDefense FinalDEF { get; private set; }
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
        HP = new HealthPoint(1000f, 1000f);
        MP = new ManaPoint(200f, 200f);
        EXP = new ExperiencePoint(0f, 1000f);

        BaseDMG = new BaseDamage(50f);
        BaseDEF = new BaseDefense(5f);
        FinalDMG = new FinalDamage(BaseDMG.Value);
        FinalDEF = new FinalDefense(BaseDEF.Value);
        CritChance = new CriticalChance(5f);
        CritDamage = new CriticalDamage(50f);
        MoveSpd = new MoveSpeed(5f);
    }
    
    // 로드된 데이터로 초기화
    private void Initialize(float hp, float maxHp, float mp, float maxMp, float exp, float maxExp, 
        float baseDmg, float baseDef, float finalDmg, float finalDef,
        float critChance, float critDamage, float moveSpd)
    {
        HP = new HealthPoint(hp, maxHp);
        MP = new ManaPoint(mp, maxMp);
        EXP = new ExperiencePoint(exp, maxExp);

        BaseDMG = new BaseDamage(baseDmg);
        BaseDEF = new BaseDefense(baseDef);
        FinalDMG = new FinalDamage(finalDmg);
        FinalDEF = new FinalDefense(finalDef);
        CritChance = new CriticalChance(critChance);
        CritDamage = new CriticalDamage(critDamage);
        MoveSpd = new MoveSpeed(moveSpd);
    }

    #endregion
}