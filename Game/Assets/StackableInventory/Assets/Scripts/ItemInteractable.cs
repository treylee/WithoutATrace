﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Module tracks whether Inventory gameobect is full
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
            Destroy(gameObject);
        }
    }
}
