using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : IGameData<string>
{
    public string Key { get; set; }
    public EQuestState State = EQuestState.CanStart;

    public string Questname;
    public string Description;

    public string TargetName;
    public int KillCount;
    public int KillToComplete;

    public int Gold;
    public int Experience;

    public Quest(string name, string des, string targetName, int killToCompletem, int gold, int exp)
    {
        Questname = name;
        Description = des;
        TargetName = targetName;
        KillToComplete = killToCompletem;

        Gold = gold;
        Experience = exp;

        Key = Questname;
    }

    public void StartQuest()
    {
        Main.Quest.OnMonsterDieIvent += AdvanceQuest;
    }

    public void GiveupQuest()
    {
        Main.Quest.OnMonsterDieIvent -= AdvanceQuest;
        KillCount = 0;
        Main.Quest.DelUPQuest(this);
    }

    public void FinishQuest()
    {
        Main.Quest.OnMonsterDieIvent -= AdvanceQuest;
        State = EQuestState.RequirementsNotMet;
        Main.Quest.DelUPQuest(this);

        Main.Game.Player.GetComponent<PlayerController>().Player.PlayerData.Exp.AddValue(Experience);
        Main.UI.SceneUI.GetComponent<MainSceneUI>().SetPlayerInfo();
    }

    public string GetGoalDescription()
    {
        string goalstr = $"{TargetName}을 {KillCount} / {KillToComplete} 마리 잡기";
        return goalstr;
    }

    public string GetRewardString()
    {
        string rewardstr = $"골드 : {Gold} G, 경험치 {Experience} EXP";
        return rewardstr;
    }

    private void AdvanceQuest(MonsterController monster)
    {
        KillCount++;
        if (KillCount >= KillToComplete) 
        {
            KillCount = KillToComplete;
            State = EQuestState.CanFinish;
        }
        Main.Quest.SetQuestList();
    }
}
