using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class node : MonoBehaviour
{
    public bool entered;
    public GameObject pencilObj;
    private Pencil pencil;
    // Start is called before the first frame update
    void Start()
    {
       
        pencil= pencilObj.GetComponent<Pencil>();
        entered = false;
    }
    void OnMouseEnter()
    {
        // load a new scene
        if (pencil.drawing)
        {
            entered = true;
            pencil.node_object = this;
        }
        Debug.Log("Entered the node: " + entered);

    }

    private void OnMouseExit()
    {
        entered = false;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
