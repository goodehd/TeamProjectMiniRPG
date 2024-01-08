using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager
{
    public QuestEvent questEvent { get; private set; }

    private Dictionary<string, Quest> _questMap;

    public QuestManager()
    {
        questEvent = new QuestEvent();
        _questMap = CreateQuestInfos();

        questEvent.OnStartQuest += StartQuest;
        questEvent.OnAdvanceQuest += AdvanceQuest;
        questEvent.OnFinishQuest += FinishQuest;
    }

    private void StartQuest(string id)
    {

    }

    private void AdvanceQuest(string id)
    {

    }

    private void FinishQuest(string id)
    {

    }

    private Dictionary<string, Quest> CreateQuestInfos()
    {
        Dictionary<string, Quest> allQuest = new Dictionary<string, Quest>();

        //TODO 데이터를 이용해 퀘스트 정보 생성

        return allQuest;
    }

    public Quest GetQuest(string id)
    {
        if(_questMap.TryGetValue(id, out Quest quest))
        {
            return quest;
        }
        return null;
    }
}
