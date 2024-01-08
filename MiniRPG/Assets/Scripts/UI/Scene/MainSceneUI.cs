using System.Collections;
using System.Collections.Generic;
using TMPro;
using UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainSceneUI : BaseUI
{
    private Player _player;

    private TextMeshProUGUI _hpText;
    private TextMeshProUGUI _hpMaxText;
    private TextMeshProUGUI _mpText;
    private TextMeshProUGUI _mpMaxText;
    private TextMeshProUGUI _expText;
    private TextMeshProUGUI _expMaxText;
    private TextMeshProUGUI _levelText;

    private Image _hpBar;
    private Image _mpBar;
    private Image _expBar;

    private Button _setiingBtn;
    private Button _invenBtn;
    private Button _statusBtn;

    private Transform _contents;

    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        SetupButton();
        SetupText();
        SetupImage();
        SetupObj();

        SetPlayerInfo();
        return true;
    }

    public void SetPlayer(Player player)
    {
        _player = player;
    }

    public void SetPlayerInfo()
    {
        if (_player == null)
            return;

        _hpText.text = ((int)(_player.PlayerData.Hp.CurValue)).ToString();
        _hpMaxText.text = ((int)(_player.PlayerData.Hp.MaxValue)).ToString();
        _hpBar.fillAmount = (_player.PlayerData.Hp.CurValue) / (_player.PlayerData.Hp.MaxValue);

        _mpText.text = ((int)(_player.PlayerData.Mp.CurValue)).ToString();
        _mpMaxText.text = ((int)(_player.PlayerData.Mp.MaxValue)).ToString();
        _mpBar.fillAmount = (_player.PlayerData.Mp.CurValue) / (_player.PlayerData.Mp.MaxValue);

        _expText.text = ((int)(_player.PlayerData.Exp.CurValue)).ToString();
        _expMaxText.text = ((int)(_player.PlayerData.Exp.MaxValue)).ToString();
        _expBar.fillAmount = (_player.PlayerData.Exp.CurValue) / (_player.PlayerData.Exp.MaxValue);
    }

    public void AddQuestList(List<Quest> quests)
    {
        foreach (Transform quest in _contents.transform)
        {
            Destroy(quest);
        }

        for(int i = 0; i < quests.Count; i++)
        {
            GameObject go = Main.Resource.InstantiatePrefab("QuestGoalTextUI", _contents.transform);
            string de = quests[i].GetGoalDescription();
            go.GetComponent<QuestGoalTextUI>().SetText(de);
        }
    }

    private void SetupButton()
    {
        SetUI<Button>();
        _setiingBtn = GetUI<Button>("Setting");
        _invenBtn = GetUI<Button>("Inven");
        _statusBtn = GetUI<Button>("Status");

        _setiingBtn.gameObject.SetEvent(UI_EVENT_TYPE.Click, SetiingBtnClick);
        _invenBtn.gameObject.SetEvent(UI_EVENT_TYPE.Click, InvenBtnClick);
        _statusBtn.gameObject.SetEvent(UI_EVENT_TYPE.Click, StatusBtnClick);
    }

    private void SetupText()
    {
        SetUI<TextMeshProUGUI>();

        _hpText = GetUI<TextMeshProUGUI>("HPText");
        _hpMaxText = GetUI<TextMeshProUGUI>("MaxHPText");
        _mpText = GetUI<TextMeshProUGUI>("MPText");
        _mpMaxText = GetUI<TextMeshProUGUI>("MaxMPText");
        _expText = GetUI<TextMeshProUGUI>("EXPText");
        _expMaxText = GetUI<TextMeshProUGUI>("MaxEXPText");
        _levelText = GetUI<TextMeshProUGUI>("LevelText");
    }

    private void SetupImage()
    {
        SetUI<Image>();

        _hpBar = GetUI<Image>("HPFillImage");
        _mpBar = GetUI<Image>("MPFillImage");
        _expBar = GetUI<Image>("EXPFillImage");
    }

    private void SetupObj()
    {
        SetUI<Transform>();

        _contents = GetUI<Transform>("Content");
    }

    private void SetiingBtnClick(PointerEventData data)
    {

    }

    private void InvenBtnClick(PointerEventData data)
    {

    }

    private void StatusBtnClick(PointerEventData data)
    {

    }
}
