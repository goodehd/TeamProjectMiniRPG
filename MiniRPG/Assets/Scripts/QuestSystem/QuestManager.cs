using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager
{
    public QuestEvent questEvent { get; private set; }

    private Dictionary<string, Quest> _questMap;
    private List<Quest> _questList;

    public QuestManager()
    {
        questEvent = new QuestEvent();
        _questMap = CreateQuestInfos();
        _questList = new List<Quest>();
    }

    public void StartQuest(Quest quest)
    {
        _questList.Add(quest);
        SetQuestList();
    }

    public void GiveUPQuest(Quest quest)
    {
        for(int i = 0; i < _questList.Count; i++)
        {
            if(_questList[i].Questname == quest.Questname)
            {
                _questList.RemoveAt(i);
            }
        }
        SetQuestList();
    }

    public void SetQuestList()
    {
        MainSceneUI sceneUI = Main.UI.SceneUI.GetComponent<MainSceneUI>();
        sceneUI.AddQuestList(_questList);
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
