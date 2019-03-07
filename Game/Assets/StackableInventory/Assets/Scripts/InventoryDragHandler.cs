using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InventoryDragHandler : ItemDragHandler
{
    private InventoryHandler inventoryHandler;

    protected override void Start()
    {
        base.Start();
        inventoryHandler = InventoryHandler.instance;
        itemSlot = inventoryHandler.currentInventory.itemSlots[slotIndex];
        thisPreviewSlot = inventoryHandler.currentInventory.previewSlot;
    }

    protected override void DropFromSlot()
    {
        //inventoryHandler.currentInventory.DropItem(itemSlot);
    }

}
