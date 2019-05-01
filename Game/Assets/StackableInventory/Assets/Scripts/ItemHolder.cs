using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHolder : ScriptableObject
{
    public ItemSlot[] itemSlots;
    public PreviewSlot previewSlot;


    [System.Serializable]
    public class ItemSlot
    {
        public Item item;
        public int currentStack;

        public ItemSlot (Item setitem, int stack)
        {
            item = setitem;
            currentStack = stack;
        }

        public void Clear()
        {
            item = null;
            currentStack = 0;
        }

        public void SetNewItem (Item newItem)
        {
            item = newItem;
            currentStack = 1;
        }
    }

    
    [System.Serializable]
    public class PreviewSlot
    {
        public Sprite previewImage;

        public PreviewSlot(Sprite setimage)
        {
            previewImage = setimage;
        }

        public void SetNewPreview(Sprite newImage)
        {
            previewImage = newImage;
        }
    }

    // For adding an item to inventory array
    public bool AddItem (Item item)
    {
        // Keeps track of whether inventory is full
        bool hasAdded = false;


        // Fills first available slot
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].item == null)
            {
                itemSlots[i].SetNewItem(item);

                // Update UI
                InventoryHandler.instance.UpdateInventoryUI();
                hasAdded = true;
                return hasAdded;
            }
        }

        // Reports if all slots are already filled
        if (!hasAdded)
        {
            Debug.Log("Inventory is full\n");
        }
        return hasAdded;
    }

    public void ClearAllItems()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].Clear();
        }
    }


}
