using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryUI : PopupUI
{
    private Transform _inventory;

    private Button _exitBtn;


    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        SetupTransform();
        SetupButton();
        

        return true;
    }

    private void SetupTransform()
    {
        SetUI<Transform>();
        _inventory = GetUI<Transform>(Literals.INVENTORY_INVENTORY_TRANSFORM);
    }

    private void SetupButton()
    {
        SetUI<Button>();
        _exitBtn = GetUI<Button>(Literals.INVENTORY_EXIT_BUTTON);
        _exitBtn.gameObject.SetEvent(UI_EVENT_TYPE.Click, ExitBtnClick);
    }

    private void ExitBtnClick(PointerEventData data)
    {
        List<UI_EVENT_TYPE> eventTypes = new List<UI_EVENT_TYPE> { UI_EVENT_TYPE.Click };
        UI.ClosePopup(this, eventTypes);
    }
}
