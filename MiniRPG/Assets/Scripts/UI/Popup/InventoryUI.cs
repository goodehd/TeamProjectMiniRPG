using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;
using UnityEngine.UI;

public class InventoryUI : PopupUI
{
    private List<ItemSlotUI> _slots;
    private int _itemCount = 0;

    private Transform _inventory;

    private Button _exitBtn;

    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        SetupTransform();
        SetupButton();
        SetupItemSlot();
        

        return true;
    }

    public void SetupTransform()
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

    private void SetupItemSlot()
    {
        for (int i = 0; i < Main.Inventory._inventoryCount; i++)
        {
            ItemSlotUI _slot = UI.SetSubItemUI<ItemSlotUI>(_inventory);
            _slots.Add(_slot);
        }

        //SetupItemIcon();
    }

    private void SetupItemIcon()
    {
        foreach(var item in Main.Inventory._inventory)
        {
            _slots[_itemCount].SetupItem();
            _itemCount++;
        }
    }

    private void ExitBtnClick(PointerEventData data)
    {
        List<UI_EVENT_TYPE> eventTypes = new List<UI_EVENT_TYPE> { UI_EVENT_TYPE.Click };
        Main.Inventory._inventoryOpend = false;
        UI.ClosePopup(this, eventTypes);
    }


    public Transform GetInventory() 
    {
        return _inventory;
    }
}
