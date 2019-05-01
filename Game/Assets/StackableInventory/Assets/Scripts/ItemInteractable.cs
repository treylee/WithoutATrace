using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteractable : Interactable
{
    public Item item;

    public override void Interact()
    {
        bool hasPickedUp = InventoryHandler.instance.currentInventory.AddItem(item);



        if (!hasPickedUp)
        {
            Debug.Log("Your bags are full!");
            return;
        }
        else
        {
            Debug.Log ("ITEM IN INVENTORY");
            Destroy(gameObject);
        }
    }
}
