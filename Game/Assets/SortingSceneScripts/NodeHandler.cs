using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeHandler : MonoBehaviour //compares the current Item to the node
{
    // Start is called before the first frame update
    string currentItemName ="";
    public GameObject itemScript;
    public SceneSystem sceneSystem; // scene control
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
            if (this.name == "ItemNode")
            {
                sceneSystem.playerHasItem = true;
                itemHandler.playPickupAnimation = true;
                
            }
            else
            {

                if (itemHandler.items.Count > 0 && sceneSystem.playerHasItem == true)
                {
                    currentItemName = itemHandler.items[itemHandler.curItem - 1].tag;
                    Debug.Log("name =" + currentItemName);
                    Debug.Log("tag =" + this.name);

                }
                if (this.name == currentItemName && sceneSystem.playerHasItem == true)
                {
                    Debug.Log("Print fxxxxxound Item");
                    sceneSystem.correctBin();
                }
                else
                {
                    sceneSystem.wrongBin();

                }
            }
            

        }
      //  Debug.Log("entered trugeer");

    }
  
}
