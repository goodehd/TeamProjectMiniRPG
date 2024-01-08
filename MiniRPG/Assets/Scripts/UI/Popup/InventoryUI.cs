using Managers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;
using UnityEngine.UI;

public class InventoryUI : PopupUI
{
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
        for (int i = 0; i < Inventory._inventoryCount; i++)
        {
            ItemSlotUI _slot = UI.SetSubItemUI<ItemSlotUI>(_inventory);
            Inventory.itemSlots.Add(_slot);
        }

        SetupItemIcon();
    }

    private void SetupItemIcon()
    {
        if (Inventory._inventory == null) return;
        foreach (var item in Inventory._inventory)
        {
            Inventory.itemSlots[_itemCount].SetupItem();
            _itemCount++;
        }
    }

    private void ExitBtnClick(PointerEventData data)
    {
        CloseInventory();
    }

    public void CloseInventory()
    {
        Inventory._inventoryOpend = false;

        PopupUI inventoryPopupUI;
        List<UI_EVENT_TYPE> inventoryEventList;
        (inventoryPopupUI, inventoryEventList) = CloseInventoryValue();

        UI.ClosePopup(inventoryPopupUI, inventoryEventList);
    }

    private (PopupUI, List<UI_EVENT_TYPE>) CloseInventoryValue()
    {
        List<UI_EVENT_TYPE> eventTypes = new List<UI_EVENT_TYPE> { UI_EVENT_TYPE.Click };

        return (this, eventTypes);
    }

public Transform GetInventory() 
    {
        return _inventory;
    }
}
