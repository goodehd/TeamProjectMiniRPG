using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour, IInteractable
{
    private List<Quest> _quests;

    private void Start()
    {
        _quests = SetQuestList();
    }

    private List<Quest> SetQuestList()
    {
        List<Quest> quests = new List<Quest>();

        // 퀘스트 매니저나 데이터 매니저에서 퀘스트 고유 번호로 퀘스트를 가져오는 작업이 필요

        // 테스트용
        quests.Add(new Quest("정훈님 어디?", "어디갔어어디갔어어디갔어어디갔어어디갔어어디갔어", "정훈님 잡아와", "골드 : 50 G, 경험치 250 EXP"));
        quests.Add(new Quest("정훈님 지각?", "지각지각지각지각지각지각지각지각지각지각지각지각", "일찍 일어나기", "골드 : 10 G, 경험치 100 EXP"));
        quests.Add(new Quest("완성 가능한가?", "어라?어라?어라?어라?어라?어라?어라?어라?어라?어라?", "프로젝트 완성하기", "골드 : 150 G, 경험치 1250 EXP"));

        return quests;
    }

    public void OnInteractionEnter()
    {
        
    }

    public void OnInteractable()
    {
        QuestUI Q_UI = Main.UI.OpenPopup<QuestUI>();
        Q_UI.SetQuestList(_quests);
    }
}
