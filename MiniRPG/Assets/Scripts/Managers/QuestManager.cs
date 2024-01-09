using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager
{
    public event Action<MonsterController> OnMonsterDieIvent;

    public List<Quest> quests { get; private set; }
    private List<Quest> _questList;

    public QuestManager()
    {
        quests = new List<Quest>();
        _questList = new List<Quest>();

        // 테스트용
        quests.Add(new Quest("몬스터 잡기 1?", "몬스터를 5마리 잡아 주세요 !", "몬스터", 5, 5, 20));
        quests.Add(new Quest("몬스터 잡기 2?", "몬스터를 10마리 잡아 주세요 !", "몬스터", 10, 10, 40));
        quests.Add(new Quest("몬스터 잡기 3?", "몬스터를 15마리 잡아 주세요 !", "몬스터", 15, 15, 60));
    }

    public void StartQuest(Quest quest)
    {
        _questList.Add(quest);
        SetQuestList();
    }

    public void DelUPQuest(Quest quest)
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

    public void OnMonsterDieIventInvoke(MonsterController monster)
    {
        OnMonsterDieIvent?.Invoke(monster);
    }

    public void SetQuestList()
    {
        MainSceneUI sceneUI = Main.UI.SceneUI.GetComponent<MainSceneUI>();
        sceneUI.AddQuestList(_questList);
    }

    //private Dictionary<string, Quest> CreateQuestInfos()
    //{
    //    Dictionary<string, Quest> allQuest = new Dictionary<string, Quest>();

    //    //TODO 데이터를 이용해 퀘스트 정보 생성

    //    return allQuest;
    //}

    //public Quest GetQuest(string id)
    //{
    //    if(_questMap.TryGetValue(id, out Quest quest))
    //    {
    //        return quest;
    //    }
    //    return null;
    //}
}
