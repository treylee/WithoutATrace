using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeHandler : MonoBehaviour //compares the current Item to the node
{
    // Start is called before the first frame update
    string currentItemName ="";
    public GameObject itemScript;
    ItemHandler itemHandler;
    string x;
    void Start()
    {

        itemHandler = itemScript.GetComponent<ItemHandler>();

    }

    // Update is called once per frame
    void Update()
    {
    //    Debug.Log("items =" + itemHandler.items.Count);


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            if (itemHandler.items.Count > 0)
            {
                currentItemName = itemHandler.items[0].tag;
                Debug.Log("name =" + currentItemName);
            }


        }
        Debug.Log("entered trugeer");

    }
  
}
