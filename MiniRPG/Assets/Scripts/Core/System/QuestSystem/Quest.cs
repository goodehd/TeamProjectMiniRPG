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

    public Quest(string name, string des)
    {
        Questname = name;
        Description = des;

        Key = Questname;
    }

    public void StartQuest()
    {

    }

    public void FinishQuest()
    {

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

    }
}
