using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class ItemSlotUI : BaseUI
{
    [SerializeField] private Item _itemSO;
    public bool isUsed = false;

    private Button _itemSlot;

    private Transform _itemIcon;
    private Transform _equipMark;

    private Image _itemIconImage;

    protected override bool Initialized()
    {
        if (!base.Initialized()) return false;

        SetupButton();
        SetupTransform();
        SetupImage();

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
    private void SetupImage()
    {
        SetUI<Image>();
        _itemIconImage = GetUI<Image>(Literals.ITEMSLOT_ITEMICON_IMAGE);
    }

    public void SetupItem(Item item)
    {
        isUsed = true;
        _itemIconImage.gameObject.SetActive(true);
        Debug.Log("아이템 장착됨");
        _itemIconImage.sprite = item.icon;
    }

    private void itemBtnClick(PointerEventData data)
    {


    }

}
