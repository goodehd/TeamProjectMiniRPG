using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/Create New Item")]

public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;
    public bool IsUsed;

    public static void CreateItemInstance(string name)
    {
  
        var asset = CreateInstance<Item>();
        AssetDatabase.CreateAsset(asset, $"Assets/Scripts/Scriptable Object/{name}.asset");
        AssetDatabase.Refresh();
    }

}
