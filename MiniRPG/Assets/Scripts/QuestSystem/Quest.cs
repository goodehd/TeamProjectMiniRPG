using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : IGameData<string>
{
    public string Key { get; set; }
    public EQuestState State = EQuestState.CanStart;

    public string Questname;
    public string Description;
    public string GoalDescription;
    public string RewardDescription;

    public int KillCount;
    public int KillToComplete;

    public int Gold;
    public int Experience;

    public Quest(string name, string des, string goal, string rewad)
    {
        Questname = name;
        Description = des;
        GoalDescription = goal;
        RewardDescription = rewad;
    }

    //public QuestInfoSO Info;
    //public EQuestState State;
    //private int currentQuestStepIndex;

    //public Quest(QuestInfoSO info)
    //{
    //    Info = info;
    //    State = EQuestState.RequirementsNotMet;
    //    currentQuestStepIndex = 0;
    //}

    //public void MoveToNextStep()
    //{
    //    currentQuestStepIndex++;
    //}

    //public bool CurrentStepExists()
    //{
    //    return currentQuestStepIndex >= Info.QuestStepPrefabs.Length;
    //}

    //public void InstantiateCurrentQuestStep(Transform parentTransform)
    //{
    //    GameObject questStep = GetCurrentQuestStepPrefab();
    //    if (questStep != null)
    //    {
    //        Object.Instantiate<GameObject>(questStep, parentTransform);
    //    }
    //}

    //private GameObject GetCurrentQuestStepPrefab()
    //{
    //    GameObject questStep = null;
    //    if (CurrentStepExists())
    //    {
    //        questStep = Info.QuestStepPrefabs[currentQuestStepIndex];
    //    }
    //    else
    //    {
    //        //경고
    //    }
    //    return questStep;
    //}
}
