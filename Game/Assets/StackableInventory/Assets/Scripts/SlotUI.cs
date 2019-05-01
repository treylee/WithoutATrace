using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class SlotUI : MonoBehaviour, IDropHandler
{
    protected GameObject icon;
    protected int slotIndex;
    private TMP_Text stack;

    protected ItemHolder.ItemSlot thisItemSlot;
    protected ItemHolder.ItemSlot droppedItemSlot;


    protected virtual void Start()
    {
        slotIndex = transform.GetSiblingIndex();
        icon = transform.GetChild(0).gameObject;
        stack = icon.transform.GetChild(0).GetComponent<TMP_Text>();
    }


    public virtual void OnDrop (PointerEventData eventData)
    {
        droppedItemSlot = eventData.pointerDrag.GetComponent<ItemDragHandler>().GetItemSlot();
    }

    protected void HandleItemDrop (PointerEventData eventData)
    {
        //droppedItemSlot = the slot you are removing an item from
        //thisItemSlot = the slot you are dropping an item to
        
        //if there's something already in the slot you are dropping into
        if (thisItemSlot.item != null)
        {
            //if the item already in the slot and the item you are dropping are the same type
            if (thisItemSlot.item == droppedItemSlot.item)
            {
                Debug.Log("SAME TYPE");
                //if the stack height for that pile has not been exceeded yet 
                if (thisItemSlot.currentStack < thisItemSlot.item.maxStack)
                {
                    Debug.Log("STACK NOT EXCEEDED");
                    //if (size of stack you are removing) + 
                    // (size of stack you are adding to) < max size of stack for that item
                    if (droppedItemSlot.currentStack <= thisItemSlot.item.maxStack - thisItemSlot.currentStack)
                    {
                        Debug.Log("MINUS");
                        //thisItemSlot.currentStack += droppedItemSlot.currentStack;
                        if (droppedItemSlot != thisItemSlot)
                        {
                            thisItemSlot.currentStack += droppedItemSlot.currentStack;
                            droppedItemSlot.Clear();
                        }
                    }
                    //if stack size is exceeded by combining the stacks above,
                    // then only a portion of the stack that is being dropped is used
                    else
                    {
                        int stackDifference = thisItemSlot.item.maxStack - thisItemSlot.currentStack;
                        thisItemSlot.currentStack += stackDifference;
                        droppedItemSlot.currentStack -= stackDifference;
                    }
                }
                else
                {
                    SwapItems(eventData);
                }
            }
            else
            {
                SwapItems(eventData);
            }
        }
        else
        {
            DropOntoEmptySlot();
        }

        //Update UI
        InventoryHandler.instance.UpdateInventoryUI();
    }

    private void DropOntoEmptySlot()
    {
        thisItemSlot.item = droppedItemSlot.item;
        thisItemSlot.currentStack = droppedItemSlot.currentStack;
        droppedItemSlot.Clear();
    }

    protected virtual void SwapItems(PointerEventData eventData)
    {
        ItemHolder.ItemSlot tempSlot = new ItemHolder.ItemSlot(thisItemSlot.item, thisItemSlot.currentStack);

        thisItemSlot.item = droppedItemSlot.item;
        thisItemSlot.currentStack = droppedItemSlot.currentStack;

        droppedItemSlot.item = tempSlot.item;
        droppedItemSlot.currentStack = tempSlot.currentStack;
    }

    public void RefreshItemIcons()
    {
        if (thisItemSlot.item != null)
        {
            icon.GetComponent<Image>().sprite = thisItemSlot.item.icon;
            if (thisItemSlot.currentStack > 0)
            {
                stack.text = "x" + thisItemSlot.currentStack;
            }
            else
            {
                stack.text = "";
            }
            icon.SetActive(true);
        }

        
        else
        {
            icon.SetActive(false);
        }
        
    }

}