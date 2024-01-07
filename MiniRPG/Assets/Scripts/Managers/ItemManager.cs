using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;



namespace Managers
{
    public class ItemManager
    {

        public List<Item> Items;
        public GameObject InventroyItem;

        public ItemManager()
        {
            Items = new List<Item>(); // list 생성 
            SetItemData();

        }
        public void AddItem(Item item)
        {
            Items.Add(item);
        }
        public void Remove(Item item)
        {
            Items.Remove(item);
        }
        public static Item GetAddComponent<Item>(GameObject obj) where Item : Component
        {
            return obj.GetComponent<Item>() ?? obj.AddComponent<Item>();
        }
        public void SetItemData() 
        {
            Debug.Log("set item");
            if (Items.Count != 0 )
            {
                Transform transform = FindItemTransform().transform;
                foreach (var item in Items)
                {
                    GameObject obj = Main.Resource.InstantiatePrefab("Item", transform);
                  
 
                    
                }
            }
        }


        private GameObject FindItemTransform()
        {
            GameObject itemObj = GameObject.Find("@Item");
            if (itemObj == null) itemObj = new GameObject { name = "@Item" };
            return itemObj;
        }

        public void MakeSOInstance(string name, int value)
        {
            Item asset = ScriptableObject.CreateInstance<Item>();
           
            asset.itemName = name;
            asset.value = value;
            AddItem(asset); 
            AssetDatabase.CreateAsset(asset, $"Assets/Scripts/Scriptable Object/items/{asset.itemName}.asset");
            AssetDatabase.Refresh();
        }

        
    }
}