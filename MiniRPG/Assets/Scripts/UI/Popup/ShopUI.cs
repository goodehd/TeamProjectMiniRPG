using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopUI : PopupUI
{
    private List<Item> _items;
    private Item _selectItem;

    private Transform _shopItemList;
    private Transform _shopItemInfo;

    private Image _shopIcon;

    private TextMeshProUGUI _shopItemName;
    private TextMeshProUGUI _shopItemDescript;

    private Button _shopItemBuyBtn;
    private Button _shopExipBtn;

    protected override bool Initialized()
    {
        if(!base.Initialized()) return false;

        SetupTransform();
        SetupImage();
        SetupText();
        SetupButton();

        SetupShopItemSlot();

        return true;
    }

    

    private void SetupTransform()
    {
        SetUI<Transform>();
        _shopItemList = GetUI<Transform>(Literals.SHOP_ITEMLIST_TRANSFORM);
        _shopItemInfo = GetUI<Transform>(Literals.SHOP_ITEMINFO_TRANSFORM);
    }

    private void SetupImage()
    {
        SetUI<Image>();
        _shopIcon = GetUI<Image>(Literals.SHOP_ITEMICON_IMAGE);
    }

    private void SetupText()
    {
        SetUI<TextMeshProUGUI>();
        _shopItemName = GetUI<TextMeshProUGUI>(Literals.SHOP_ITEMNAME_TEXT);
        _shopItemDescript = GetUI<TextMeshProUGUI>(Literals.SHOP_ITEMDESCRIPT_TEXT);
    }

    private void SetupButton()
    {
        SetUI<Button>();
        _shopItemBuyBtn = GetUI<Button>(Literals.SHOP_ITEMBUY_BUTTON);
        _shopExipBtn = GetUI<Button>(Literals.SHOP_EXIT_BUTTON);
        
        _shopItemBuyBtn.gameObject.SetEvent(UI_EVENT_TYPE.Click, BuyBtnClick);
        _shopExipBtn.gameObject.SetEvent(UI_EVENT_TYPE.Click, ExitBtnClick);
    }

    private void BuyBtnClick(PointerEventData data)
    {
        Main.Inventory.AddItem(_selectItem);

    }
    private void ExitBtnClick(PointerEventData data)
    {
        List<UI_EVENT_TYPE> eventTypes = new List<UI_EVENT_TYPE> { UI_EVENT_TYPE.Click };
        Main.UI.ClosePopup(this, eventTypes);

    }

    public void SetupShopItemSlot()
    {
        //ShopItemSlotUI _slot = UI.SetSubItemUI<ShopItemSlotUI>(_shopItemList);

        foreach (var item in _items)
        {
            ShopItemSlotUI slot = UI.SetSubItemUI<ShopItemSlotUI>(_shopItemList);
            slot.SetOwner(this);
            slot.SetItem(item);
        }
    }

    public void SetItems(List<Item> items)
    {
        _items = items;
    }


    public void SetShopInfo(Item info)
    {
        _shopItemInfo.gameObject.SetActive(true);

        _selectItem = info;

        _shopItemName.text = info.name;
        _shopItemDescript.text = info.description;
        _shopIcon.sprite = info.icon;


    }

}
