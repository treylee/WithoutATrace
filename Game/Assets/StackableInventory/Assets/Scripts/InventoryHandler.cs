using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryHandler : MonoBehaviour
{
    public static InventoryHandler instance;

    public Inventory currentInventory;

    //private GameObject inventoryPanel;

    private InventorySlotUI[] inventorySlotUIs;

    private PreviewUI previewUI;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        Debug.Log("HAPPENING");
        inventorySlotUIs = FindObjectsOfType<InventorySlotUI>();
        currentInventory.ClearAllItems();
        previewUI = FindObjectOfType<PreviewUI>();
    }

    public void UpdateInventoryUI()
    {
        for (int i = 0; i < inventorySlotUIs.Length; i++)
        {
            inventorySlotUIs[i].RefreshItemIcons();
        }
        
    }

    /*
    public void UpdatePreviewUI()
    {
        previewUI.RefreshPreview();
    }
    */

    public void AddItemButton (Item item)
    {
        currentInventory.AddItem(item);
        UpdateInventoryUI();
    }
}
