using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyItem : MonoBehaviour
{
    // Start is called before the first frame update
    private string itemName;
    private bool grabbingItem;
    private GameObject curItem;
    private GameObject backpack;
    private GameObject inventoryObj;
    private GameObject player;
    private PlayerController p;
    private MyInventory inventory;
    private int itemScale;
    float speed = 0;
    float step = 0;
    void Start()
    {
        itemName = gameObject.name;
        player = GameObject.FindGameObjectWithTag("Player");
        inventoryObj = GameObject.FindGameObjectWithTag("Inventory");
        p = player.GetComponent<PlayerController>();
        inventory = inventoryObj.GetComponent<MyInventory>();
        grabbingItem = false;
        itemScale = 0;
        

    }

    // Update is called once per frame
    void Update()
    {
        if (grabbingItem == true)
        {
            if (itemScale < 20)
            {
                Debug.Log("itemScale");
                transform.localScale += new Vector3(0.01F, 0.01f, 0f);
                transform.position += new Vector3(0.0F, 0.4f, 0.0f);

                itemScale++;
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, p.step * 2.90f);
                if (transform.localScale.x > 0.04f)
               transform.localScale += new Vector3(-0.04F, -0.04f, 0f);

                if (Vector3.Distance(transform.position, player.transform.position) < 0.4f)
                {
                    Debug.Log("end");
                    gameObject.SetActive(false);
                    grabbingItem = false;
                    itemScale = 0;
                    inventory.addItem(this);
                    inventory.printItems();

                }

            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
     
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Picked up an Item");
            itemName = this.name;
            grabbingItem = true;
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
   
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Picked up an Item");
            itemName = this.name;
            grabbingItem = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
   
        if (other.gameObject.tag.Equals("Player"))
        {
            Debug.Log("Picked up an Item");
            itemName = this.name;

            grabbingItem = true;
        }
    }
    public string getName()
    {
        return this.name;
    }
}
