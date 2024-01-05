using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class QuestButton : BaseUI
{
    private QuestUI _Owner;
    private Quest _quest;

    private Button _questBtn;

    private TextMeshProUGUI _questName;

    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        SetupButton();
        SetupText();

        _questName.text = _quest.Questname;

        return true;
    }

    private void SetupButton()
    {
        SetUI<Button>();
        _questBtn = GetUI<Button>("QuestBtn(Clone)");
        _questBtn.gameObject.SetEvent(UIEventType.Click, QuestBtnClick);
    }

    private void SetupText()
    {
        SetUI<TextMeshProUGUI>();
        _questName = GetUI<TextMeshProUGUI>("QuestText");
    }

    public void SetQuest(Quest quest)
    {
        _quest = quest;
    }

    public void SetOwner(QuestUI questUI)
    {
        _Owner = questUI;
    }

    private void QuestBtnClick(PointerEventData data)
    {
        _Owner.SetQuestInfo(_quest);
    }
}
