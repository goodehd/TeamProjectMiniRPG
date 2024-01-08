using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class ItemSlotUI : BaseUI
{
    [SerializeField] private Item _itemSO;
    private Button _itemSlot;

    private Transform _itemIcon;
    private Transform _equipMark;


    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        SetupButton();
        SetupTransform();

        return true;
    }

    private void SetupButton()
    {
        SetUI<Button>();
        _itemSlot = GetUI<Button>(Literals.ITEMSLOT_ITEMSLOT_BUTTON);
        _itemSlot.gameObject.SetEvent(UI_EVENT_TYPE.Click, itemBtnClick);
    }


    private void SetupTransform()
    {
        SetUI<Transform>();
        _itemIcon = GetUI<Transform>(Literals.ITEMSLOT_ITEMICON_TRANSFORM);
        _equipMark = GetUI<Transform>(Literals.ITEMSLOT_EQUIPMARK_TRANSFORM);
    }

    public void SetupItem()
    {
        _itemIcon.gameObject.SetActive(true);
        Debug.Log("아이템 장착됨");
    }

    private void itemBtnClick(PointerEventData data)
    {


    }

}
