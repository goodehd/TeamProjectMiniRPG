using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Intro_UI : BaseUI
{
    private Button _touchBtn;
    private TextMeshProUGUI _text;

    protected override bool Initialized()
    {
        if(!base.Initialized()) return false;

        SetupButton();
        SetupText();

        return true;
    }


    private void SetupButton()
    {
        SetUI<Button>();
        _touchBtn = GetUI<Button>(Literals.INTRO_BUTTON);
        _touchBtn.gameObject.SetEvent(UI_EVENT_TYPE.Click, TouchIntroButton);

    }
    private void SetupText()
    {
        SetUI<TextMeshProUGUI>();
        _text = GetUI<TextMeshProUGUI>("TuchText");
    }

    private void TouchIntroButton(PointerEventData data)
    {

        Main.Scenes.NextScene = "Select";
        Main.Scenes.CurrentScene = "Intro";
        Main.Scenes.LoadLoadingScene();
        Debug.Log("눌렸음");
        _text.text = "눌려짐";
    }
}
