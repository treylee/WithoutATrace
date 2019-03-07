using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class InventorySlotUI : SlotUI
{
    
    protected override void Start()
    {
        base.Start();
        thisItemSlot = InventoryHandler.instance.currentInventory.itemSlots[slotIndex];
    }

    
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
        if (eventData.pointerDrag.transform.parent == gameObject)
        {
            return;
        }

        HandleItemDrop(eventData);
        
    }
}
