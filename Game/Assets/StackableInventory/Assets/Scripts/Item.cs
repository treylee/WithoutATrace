using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Module instantiates items and creates item characteristics
[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName { get; set; }
    public string itemDescription { get; set; }
    public Sprite icon;
    public int itemPrice { get; set; }
    public ItemTypes itemType = ItemTypes.Undefined;
    public int currentStack = 1;
    public int maxStack = 1;

    public static explicit operator Item(GameObject v)
    {
        throw new NotImplementedException();
    }
}
