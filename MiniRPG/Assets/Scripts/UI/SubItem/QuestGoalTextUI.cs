using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;

public class QuestGoalTextUI : BaseUI
{
    private TextMeshProUGUI _goalText;
    private string _text;
    private Color _textColor = Color.white;

    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        SetupText();

        _goalText.text = _text;
        _goalText.color = _textColor;

        return true;
    }

    public void SetText(string text)
    {
        _text = text;
    }

    public void SetTextColor(Color color)
    {
        _textColor = color;
    }

    private void SetupText()
    {
        SetUI<TextMeshProUGUI>();

        _goalText = GetUI<TextMeshProUGUI>("QuestGoalTextUI");
    }
}
