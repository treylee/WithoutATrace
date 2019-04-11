using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_Button : MonoBehaviour
{

    // Flag indicating whether game is paused
    public static bool isPaused = false;

    // Inventory Panel that script is attached to
    public GameObject InventoryBlock;

    void Start ()
    {
        DisapparateInventory();
    }

    // Update is called once per frame
    public void ToggleInventory (bool status)
    {
        status = isPaused;
        if (!status)
        {
            // Show inventory
            ApparateInventory();
        }
        else
        {
            // Do not show Inventory
            DisapparateInventory();
        }
    }

    public void DisapparateInventory ()
    {
        InventoryBlock.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void ApparateInventory ()
    {
        InventoryBlock.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
}
