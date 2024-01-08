using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UI;
using UnityEngine.UI;
using TMPro;
using System;
using UnityEngine.EventSystems;
using UnityEditor.PackageManager.Requests;

public class ShopItemSlotUI : BaseUI
{
    private Item _item;
    private ShopUI _Owner;
    private Image _shopItemIcon;

    private TextMeshProUGUI _shopItemName;

    private Button _ShopItemButton;

    protected override bool Initialized()
    {
        if(!base.Initialized()) return false;

        SetupButton();
        SetupImage();
        SetupText();

        SetData();

        return true;
    }

    private void SetupButton()
    {
        SetUI<Button>();
        _ShopItemButton = GetUI<Button>(Literals.SHOP_ITEMSLOT_BUTTON);
        _ShopItemButton.gameObject.SetEvent(UI_EVENT_TYPE.Click, ShopSlotClick);
    }

    

    private void SetupImage()
    {
        SetUI<Image>();
        _shopItemIcon = GetUI<Image>(Literals.SHOP_ITEMSLOT_ICON_IMAGE);
    }

    private void SetupText()
    {
        SetUI<TextMeshProUGUI>();
        _shopItemName = GetUI<TextMeshProUGUI>(Literals.SHOP_ITEMSLOT_NAME_TEXT);
    }


    private void ShopSlotClick(PointerEventData data)
    {
        _Owner.SetShopInfo(_item);
    }

    

    public void SetOwner(ShopUI owner)
    {
        _Owner = owner;
    }

    public void SetItem(Item item)
    {
        _item = item;
    }

    private void SetData()
    {
        _shopItemIcon.sprite = _item.icon;
        _shopItemName.text = _item.name;
    }
}
