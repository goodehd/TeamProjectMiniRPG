using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Select_UI : BaseUI
{
    private Camera _camera;
    private Canvas _selectCanvas;

    private Button _maleBtn;
    private Button _femaleBtn;

    private TextMeshProUGUI _maleJobText;
    private TextMeshProUGUI _maleLvText;
    private TextMeshProUGUI _femaleJobText;
    private TextMeshProUGUI _femaleLvText;

    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        SetupCamera();
        SetupCanvas();
        SetupButton();
        SetupText();

        return true;
    }

    private void SetupCamera()
    {
        _camera = Camera.main;
        Debug.Log(_camera.name);
    }

    private void SetupCanvas()
    {
        _selectCanvas = gameObject.GetComponent<Canvas>();
        _selectCanvas.worldCamera = _camera;
        
    }

    private void SetupButton()
    {
        SetUI<Button>();
        _maleBtn = GetUI<Button>(Literals.SELECT_MALE_BUTTON);
        _femaleBtn = GetUI<Button>(Literals.SELECT_FEMALE_BUTTON);
        
        _maleBtn.gameObject.SetEvent(UIEventType.Click, TouchIntroButton);
        _femaleBtn.gameObject.SetEvent(UIEventType.Click, TouchIntroButton);

    }
    private void SetupText()
    {
        SetUI<TextMeshProUGUI>();
        _maleJobText = GetUI<TextMeshProUGUI>(Literals.SELECT_MALE_JOB_TEXT);
        _maleLvText = GetUI<TextMeshProUGUI>(Literals.SELECT_MALE_LV_TEXT);
        _femaleJobText = GetUI<TextMeshProUGUI>(Literals.SELECT_FEMALE_JOB_TEXT);
        _femaleLvText = GetUI<TextMeshProUGUI>(Literals.SELECT_FEMALE_LV_TEXT);
    }

    private void TouchIntroButton(PointerEventData data)
    {
    }

}
