using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyItem : MonoBehaviour
{
    // Name of item
    private string itemName;

    // Flag indicating whether an item
    // is being picked up
    private bool grabbingItem;

    //
    private GameObject curItem;

    //
    private GameObject backpack;

    //
    private InventoryHandler inventoryObj;

    // Represents the main character
    private GameObject player;

    //
    private PlayerController p;

    //
    public Item item;

    //
    private int itemScale;

    //
    float speed = 0;

    //
    float step = 0;

    private bool hasTriggered;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        if (inventoryObj != null)
        {
            Debug.Log("found inventory");
        }

        p = player.GetComponent<PlayerController>();
        grabbingItem = false;
        itemScale = 0;
        hasTriggered = false;
    }


    // Checks if player is close to item; handles
    // item "animation" as part of collection of item
    
    void Update()
    {
        if (grabbingItem == true)
        {
            // Checks that the size of the item is
            // small enough for it to be "highlighted"
            // before allowing character to collect it
            if (itemScale < 20)
            {
                // Make the item grow in size (to give appearance of
                // highlighting it) before allowing character to collect it
                transform.localScale += new Vector3(0.01F, 0.01f, 0f);

                // Make the item ascend in the y-axis (to give appearance of
                // highlighting it) before allowing character to collect it
                transform.position += new Vector3(0.0F, 0.4f, 0.0f);

                // Increases scale variable so item can only expand 20 times,
                // before shrinking and descending (see else statement below)
                itemScale++;
            }

            else
            {
                // Make the item descend in the y-axis (after highlighting it)
                // closer to the character before allowing character to collect it;
                // gives appearance that item is falling into backpack
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, p.step * 2.90f);

                // Make the item shrink in scale (after highlighting it)
                // before allowing character to collect it; gives appearance
                // that item is shrinking into backpack
                if (transform.localScale.x > 0.04f)
                {
                    transform.localScale += new Vector3(-0.04F, -0.04f, 0f);
                }

                // Checks if distance between item and player is negligible;
                // appearance of item does not matter at that point, so
                // changes item scale to zero before allowing character
                // to collect it
                if (Vector3.Distance(transform.position, player.transform.position) < 0.4f)
                {
                    Debug.Log("end");
                    gameObject.SetActive(false);
                    grabbingItem = false;
                    itemScale = 0;
                }
            }
        }
    }
    

    // Handles item-character interaction at
    // instant of collision
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player") && hasTriggered == false)
        {
            Debug.Log("enter");
            itemName = name;
            grabbingItem = true;
        }
    }

    // Handles item-character interaction through duration
    // of collision
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            itemName = name;
            grabbingItem = true;
        }
    }

    // Handles item-character interaction at end of
    // collision
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("Player") && hasTriggered == false)
        {
            Debug.Log("going");
            hasTriggered = true;
            if (item == null)
            {
                Debug.Log("item does not exist");
            }
            grabbingItem = true;
            item.GenerateTitle(itemName);  
            try
            {
                //This line picks up the item.
                InventoryHandler.instance.currentInventory.AddItem(item);
            }
            catch (Exception)
            {
                Debug.Log("ERROR");
            }
        }
    }

    // Fetches name of this item
    public string getName()
    {
        return name;
    }
}
