using Scene;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class testscnen : BaseScene
{
    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        Object eventSystem = FindObjectOfType<EventSystem>();

        Main.Resource.AllLoadResource<Object>("test", (key, loadCount, totalCount) =>
        {
            if (loadCount == totalCount)
            {
                if (eventSystem == null) Main.Resource.InstantiatePrefab("EventSystem");


                List<Quest> quests = new List<Quest>();
                quests.Add(new Quest("정훈님 어디?", "어디갔어어디갔어어디갔어어디갔어어디갔어어디갔어", "정훈님 잡아와", "골드 : 50 G, 경험치 250 EXP"));
                quests.Add(new Quest("정훈님 지각?", "지각지각지각지각지각지각지각지각지각지각지각지각", "일찍 일어나기", "골드 : 10 G, 경험치 100 EXP"));
                quests.Add(new Quest("완성 가능한가?", "어라?어라?어라?어라?어라?어라?어라?어라?어라?어라?", "프로젝트 완성하기", "골드 : 150 G, 경험치 1250 EXP"));
                quests.Add(new Quest("정훈님 어디?", "어디갔어어디갔어어디갔어어디갔어어디갔어어디갔어", "정훈님 잡아와", "골드 : 50 G, 경험치 250 EXP"));
                quests.Add(new Quest("정훈님 지각?", "지각지각지각지각지각지각지각지각지각지각지각지각", "일찍 일어나기", "골드 : 10 G, 경험치 100 EXP"));
                quests.Add(new Quest("완성 가능한가?", "어라?어라?어라?어라?어라?어라?어라?어라?어라?어라?", "프로젝트 완성하기", "골드 : 150 G, 경험치 1250 EXP"));
                quests.Add(new Quest("정훈님 어디?", "어디갔어어디갔어어디갔어어디갔어어디갔어어디갔어", "정훈님 잡아와", "골드 : 50 G, 경험치 250 EXP"));
                quests.Add(new Quest("정훈님 지각?", "지각지각지각지각지각지각지각지각지각지각지각지각", "일찍 일어나기", "골드 : 10 G, 경험치 100 EXP"));
                quests.Add(new Quest("완성 가능한가?", "어라?어라?어라?어라?어라?어라?어라?어라?어라?어라?", "프로젝트 완성하기", "골드 : 150 G, 경험치 1250 EXP"));

                QuestUI Q_UI = UI.OpenPopup<QuestUI>();
                Q_UI.SetQuestList(quests);
            }
        });
        return true;
    }
}
