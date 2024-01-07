using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemTestScene : MonoBehaviour
{
    public Item item;
    // Start is called before the first frame update
    void Start()
    {
        Main.Resource.AllLoadResource<Object>("Preload", (key, count, totalCount) =>
        {
            Debug.Log($"[BaseScene] Load asset {key} ({count}/{totalCount})");
            if(count == totalCount)
            {
                Main.Item.MakeSOInstance("item1", 10);
                Main.Item.MakeSOInstance("item2", 10);
                Main.Item.MakeSOInstance("item3", 20);
                Main.Item.SetItemData();
            }
        });

        
    }

}
