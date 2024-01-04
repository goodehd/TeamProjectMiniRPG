using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;

public class SkillTooltip_UI : BaseUI
{
    private TextMeshProUGUI _skillTooltip;

    protected override bool Initialized()
    {
        if (base.Initialized()) return false;
        SetupText();
        return true;
    }

    private void SetupText()
    {
        SetUI<TextMeshProUGUI>();
        _skillTooltip = GetUI<TextMeshProUGUI>("SkillTooltip");
    }

    public void SetText(string tooltip)
    {
        _skillTooltip.text = tooltip;
    }

}
