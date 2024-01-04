using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;

public class TestInventory_UI : PopupUI
{
    private Button _exitBtn;
    private TextMeshProUGUI _exitBtnText;
    private Transform _inventory;

    private TextMeshProUGUI _startBtnText;
    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;
        SetupExitBtn();
        SetupInventory();
        SetupExitBtnText();
        return true;
    }
    private void SetupExitBtn()
    {
        SetUI<Button>();
        _exitBtn = GetUI<Button>("ExitBtn");
        //_exitBtn.onClick.AddListener(CloseInventory);
        _exitBtn.gameObject.SetEvent(UIEventType.Click, CloseInventory);
    }

    private void SetupInventory()
    {
        SetUI<Transform>();
        _inventory = GetUI<Transform>("Inventory");
    }

    private void SetupExitBtnText()
    {
        SetUI<TextMeshProUGUI>();
        _exitBtnText = GetUI<TextMeshProUGUI>("ExitBtnText");
    }


    private void CloseInventory(PointerEventData obj)
    {
        DescribeEventTypes();
    }


    public void DescribeEventTypes()
    {
        List<UIEventType> eventTypes = new List<UIEventType> { UIEventType.Click };
        UI.ClosePopup(this, eventTypes);
    }

}
