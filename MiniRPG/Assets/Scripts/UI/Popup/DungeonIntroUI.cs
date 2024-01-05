using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static UnityEditor.PlayerSettings;

public class DungeonIntroUI : PopupUI
{
    private Image _privewImage;

    private TextMeshProUGUI _dungeonNameText;
    private TextMeshProUGUI _dungeonDescriptsText;
    private TextMeshProUGUI _selectLevelText;

    private Button _enterButton;
    private Button _Level1Button;
    private Button _Level2Button;
    private Button _exitBtn;

    private DungeonLevel _selectLevel;
    private DungeonData _dungeonData;

    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        SetupImage();
        SetupButton();
        SetupText();

        SetDungeonInfos();

        return true;
    }

    public void SetDungeonData(DungeonData dungeonData)
    {
        _dungeonData = dungeonData;
    }

    private void SetDungeonInfos()
    {
        if (_dungeonData == null)
            return;

        Sprite image = Main.Resource.Load<Sprite>($"{_dungeonData.PrivewImageKey}.sprite");

        _privewImage.sprite = image;
        _dungeonNameText.text = _dungeonData.DungeonName;
        _dungeonDescriptsText.text = _dungeonData.DungeonDescripts;
    }

    private void SetupText()
    {
        SetUI<TextMeshProUGUI>();

        _dungeonNameText = GetUI<TextMeshProUGUI>("DungeonNameText");
        _dungeonDescriptsText = GetUI<TextMeshProUGUI>("DungeonDescriptsText");
        _selectLevelText = GetUI<TextMeshProUGUI>("SlectLevelText");
    }

    private void SetupButton()
    {
        SetUI<Button>();

        _enterButton = GetUI<Button>("EnterButton");
        _Level1Button = GetUI<Button>("Level1Button");
        _Level2Button = GetUI<Button>("Level2Button");
        _exitBtn = GetUI<Button>("ExitBtn");

        _enterButton.gameObject.SetEvent(UI_EVENT_TYPE.Click, EnterBtnClick);
        _Level1Button.gameObject.SetEvent(UI_EVENT_TYPE.Click, Level1BtnClick);
        _Level2Button.gameObject.SetEvent(UI_EVENT_TYPE.Click, Level2BtnClick);
        _exitBtn.gameObject.SetEvent(UI_EVENT_TYPE.Click, ExitBtnClick);
    }

    private void SetupImage()
    {
        SetUI<Image>();

        _privewImage = GetUI<Image>("PrivewImage");
    }

    private void ExitBtnClick(PointerEventData data)
    {
        Destroy(gameObject);
    }

    private void EnterBtnClick(PointerEventData data)
    {
        // TODO 던전 씬 로드 코드 작성
        Main.Scenes.NextScene = _dungeonData.DungeonSceneName;
        Main.Scenes.LoadLoadingScene();
    }

    private void Level1BtnClick(PointerEventData data)
    {
        _selectLevel = DungeonLevel.Level1;
        _selectLevelText.text = "1";
    }

    private void Level2BtnClick(PointerEventData data)
    {
        _selectLevel = DungeonLevel.Level2;
        _selectLevelText.text = "2";
    }
}
