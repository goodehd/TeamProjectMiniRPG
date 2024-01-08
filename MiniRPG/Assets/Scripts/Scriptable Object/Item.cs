using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

public class Item : ScriptableObject
{
    public string itemName; // 이름
    public int value; // 공격력, 마나, 체력..  
    public Sprite icon; //이미지 아이콘
    public bool IsUsed;
    public ItemType itemType;
    public string description;

    public enum ItemType
    {
        Potion,
        Weapon,
        Armor
    }

}
