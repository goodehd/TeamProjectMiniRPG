using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    private Button _startBtn;

    private TextMeshProUGUI _maleJobText;
    private TextMeshProUGUI _maleLvText;
    private TextMeshProUGUI _femaleJobText;
    private TextMeshProUGUI _femaleLvText;

    private SelectScene _selectScene;

    private bool _isSelect = false;
    PlayerMale _playerMale;
    PlayerFemale _playerFemale;

    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        SetupSelectScene();
        SetupCamera();
        SetupCanvas();
        SetupButton();
        SetupText();

        _playerMale = _selectScene.GetPlayerMale();
        _playerFemale = _selectScene.GetPlayerFemale();

        return true;
    }

    private void SetupSelectScene()
    {
        _selectScene = Main.Scenes.CurrentSceneObject.GetComponent<SelectScene>();  
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
        _startBtn = GetUI<Button>(Literals.SELECT_START_BUTTON);
        
        _maleBtn.gameObject.SetEvent(UI_EVENT_TYPE.Click, MaleButton);
        _femaleBtn.gameObject.SetEvent(UI_EVENT_TYPE.Click, FemaleButton);
        _startBtn.gameObject.SetEvent(UI_EVENT_TYPE.Click, StartButton);

    }

    

    private void SetupText()
    {
        SetUI<TextMeshProUGUI>();
        _maleJobText = GetUI<TextMeshProUGUI>(Literals.SELECT_MALE_JOB_TEXT);
        _maleLvText = GetUI<TextMeshProUGUI>(Literals.SELECT_MALE_LV_TEXT);
        _femaleJobText = GetUI<TextMeshProUGUI>(Literals.SELECT_FEMALE_JOB_TEXT);
        _femaleLvText = GetUI<TextMeshProUGUI>(Literals.SELECT_FEMALE_LV_TEXT);
    }


    private void MaleButton(PointerEventData data)
    {
        SelectedCharacter(UI_SELECT_CHARACTER.Male);

        if (_isSelect) return;
        _startBtn.gameObject.SetActive(true);
    }

    private void FemaleButton(PointerEventData data)
    {
        SelectedCharacter(UI_SELECT_CHARACTER.Female);

        if (_isSelect) return;
        _startBtn.gameObject.SetActive(true);
    }

    private void SelectedCharacter(UI_SELECT_CHARACTER character)
    {
        if(character == UI_SELECT_CHARACTER.Male)
        {
            _playerMale.SetSelectTrue();
            _playerFemale.SetSelectFalse();
        }
        else
        {
            _playerMale.SetSelectFalse();
            _playerFemale.SetSelectTrue();
        }
    }

    private void StartButton(PointerEventData data)
    {
        Main.Scenes.NextScene = "Game";
        Main.Scenes.CurrentScene = "Select";
        Main.Scenes.LoadLoadingScene();
    }
}
