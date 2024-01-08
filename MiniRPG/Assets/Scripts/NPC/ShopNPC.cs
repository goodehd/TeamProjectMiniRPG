using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNPC : MonoBehaviour, IInteractable
{
    [SerializeField] private List<Item> _items;

    private void Start()
    {
        //_items = SetItemList();
    }

    private List<Item> SetItemList()
    {
        List<Item> items = Main.Item.Items;


        // 퀘스트 매니저나 데이터 매니저에서 퀘스트 고유 번호로 퀘스트를 가져오는 작업이 필요
        return items;
    }



    public void OnInteractionEnter()
    {
    }

    public void OnInteractable()
    {
        ShopUI Shop_UI = Main.UI.OpenPopup<ShopUI>();
        Shop_UI.SetItems(_items);
        //Shop_UI.SetupShopItemSlot();
    }

    public void OnInteractableExit()
    {
    }
}
