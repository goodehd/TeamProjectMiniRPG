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
        Main.Item.MakeSOInstance("item1", 10);
        Main.Item.MakeSOInstance("item2", 10);

    }

}
