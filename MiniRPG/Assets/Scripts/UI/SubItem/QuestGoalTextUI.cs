using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;

public class QuestGoalTextUI : BaseUI
{
    private TextMeshProUGUI _goalText;

    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        SetupText();

        return true;
    }

    public void SetText(string text)
    {
        _goalText.text = text;
    }

    private void SetupText()
    {
        SetUI<TextMeshProUGUI>();

        _goalText = GetUI<TextMeshProUGUI>("QuestGoalText");
    }
}
