using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class QuestUI : PopupUI
{
    private List<Quest> _quests;
    private Quest _selectQuests;

    private TextMeshProUGUI _questName;
    private TextMeshProUGUI _questDescript;
    private TextMeshProUGUI _questGoal;
    private TextMeshProUGUI _questReward;

    private Button _exitBtn;
    private Button _acceptBtn;
    private Button _giveUpBtn;
    private Button _completionBtn;

    private Transform _infos;
    private Transform _questList;

    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        SetupButton();
        SetupText();
        SetupGameObject();

        for(int i = 0; i < _quests.Count; ++i)
        {
            GameObject btn = Main.Resource.InstantiatePrefab("QuestBtn", _questList.transform);
            QuestButton btnScrip = btn.GetComponent<QuestButton>();
            btnScrip.SetQuest(_quests[i]);
            btnScrip.SetOwner(this);
        }

        _infos.gameObject.SetActive(false);

        return true;
    }

    public void SetQuestList(List<Quest> quests)
    {
        _quests = quests;
    }

    public void SetQuestInfo(Quest info)
    {
        _infos.gameObject.SetActive(true);

        _selectQuests = info;

        _questName.text = info.Questname;
        _questDescript.text = info.Description;
        _questGoal.text = info.GetGoalDescription();
        _questReward.text = info.GetRewardString();

        SetBtnActiveFalse();

        switch(info.State)
        {
            case EQuestState.CanStart:
                _acceptBtn.gameObject.SetActive(true);
                break;
            case EQuestState.InProgress:
                _giveUpBtn.gameObject.SetActive(true);
                break;
            case EQuestState.CanFinish:
                _completionBtn.gameObject.SetActive(true);
                break;
        }
    }

    private void SetBtnActiveFalse()
    {
        _acceptBtn.gameObject.SetActive(false);
        _giveUpBtn.gameObject.SetActive(false);
        _completionBtn.gameObject.SetActive(false);
    }

    private void SetupButton()
    {
        SetUI<Button>();
        _exitBtn = GetUI<Button>("ExitBtn");
        _acceptBtn = GetUI<Button>("AcceptBtn");
        _giveUpBtn = GetUI<Button>("GiveUpBtn");
        _completionBtn = GetUI<Button>("CompletionBtn");

        _exitBtn.gameObject.SetEvent(UI_EVENT_TYPE.Click, ExitBtnClick);
        _acceptBtn.gameObject.SetEvent(UI_EVENT_TYPE.Click, AcceptBtnClick);
        _giveUpBtn.gameObject.SetEvent(UI_EVENT_TYPE.Click, GiveUpBtnClick);
        _completionBtn.gameObject.SetEvent(UI_EVENT_TYPE.Click, CompletionBtnClick);
    }

    private void SetupText()
    {
        SetUI<TextMeshProUGUI>();
        _questName = GetUI<TextMeshProUGUI>("QuestNameText");
        _questDescript = GetUI<TextMeshProUGUI>("QuestDescriptText");
        _questGoal = GetUI<TextMeshProUGUI>("QuestGoalText");
        _questReward = GetUI<TextMeshProUGUI>("QuestRewardText");
    }

    private void SetupGameObject()
    {
        SetUI<ContentSizeFitter>();

        SetUI<Transform>();

        _questList = GetUI<Transform>("Content");
        _infos = GetUI<Transform>("QuestInfos");
    }

    private void ExitBtnClick(PointerEventData data)
    {
        Destroy(gameObject);
    }

    private void AcceptBtnClick(PointerEventData data)
    {
        _selectQuests.State = EQuestState.InProgress;
        SetQuestInfo(_selectQuests);
    }

    private void GiveUpBtnClick(PointerEventData data)
    {
        _selectQuests.State = EQuestState.CanStart;
        SetQuestInfo(_selectQuests);
    }

    private void CompletionBtnClick(PointerEventData data)
    {

    }
}
