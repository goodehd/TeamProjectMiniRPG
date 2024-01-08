using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestNPC : MonoBehaviour, IInteractable
{
    private List<Quest> _quests;
    private GameObject _interUI;

    private void Start()
    {
        _quests = SetQuestList();
    }

    private List<Quest> SetQuestList()
    {
        List<Quest> quests = new List<Quest>();

        // 퀘스트 매니저나 데이터 매니저에서 퀘스트 고유 번호로 퀘스트를 가져오는 작업이 필요


        return quests;
    }

    public void OnInteractionEnter()
    {
        GameObject go = Main.Resource.InstantiatePrefab("InteractableUI", transform);
        _interUI = go;
    }

    public void OnInteractable()
    {
        QuestUI Q_UI = Main.UI.OpenPopup<QuestUI>();
        Q_UI.SetQuestList(Main.Quest.quests);
    }

    public void OnInteractableExit()
    {
        Destroy(_interUI);
    }
}
