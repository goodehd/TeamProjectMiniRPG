using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    Item item;

    public void RemoveItem(){ //포션류에서만 사용 
        Main.Item.Remove(item);
        Destroy(gameObject);
    }

    public void UseItem()
    {
        switch (item.itemType)
        {
            case Item.ItemType.Potion:
                //체력 증가 / player에서 새로 함수 추가하면 좋을듯? 
                RemoveItem();
                item.IsUsed = true;
                break;
            case Item.ItemType.Weapon: 
                //공격력 증가/감소
                item.IsUsed = !item.IsUsed; 
                break;
            case Item.ItemType.Armor:
                //방어력 증가/감소
                item.IsUsed = !item.IsUsed;
                break;
        }
    }
  
}
