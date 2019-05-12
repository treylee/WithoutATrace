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

    /*
    void Update()
    {
        int numTouches = 0;
        if (Input.touchCount > 0)
        {
            ++numTouches;




            
            if (Input.touchCount > 0 && numTouches > 0)
            {
                Debug.Log("Touch");
            }
           
        }
    }
    */


    /*
    public void OnPointerEnter(PointerEventData eventData)
    {
        /*
        Debug.Log("works");
        while (eventData.clickTime < 0.1f) //& gameObject.GetComponentInChildren<InventoryDragHandler>() != null)
        {
            if (eventData.clickCount == 2) // && gameObject.GetComponentInChildren<InventoryDragHandler>() != null)
            {
                Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
            }
        }
        */

    
}
