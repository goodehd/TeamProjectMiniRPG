using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTestScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Item newItem = ScriptableObject.CreateInstance<Item>();
        newItem.itemName = "1";
        Main.Item.AddItem(newItem);
   



    }

}
