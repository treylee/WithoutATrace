using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInventory : MonoBehaviour
{
    // Start is called before the first frame update
    private List<MyItem> items = new List<MyItem>();
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void addItem(MyItem item)
    {
        items.Add(item);
    }
    public void getItem(MyItem item)
    {
        items.Remove(item);
    }
    public void printItems()
    {
        foreach (MyItem i in items)
        {
            Debug.Log(i.getName());
        }

    }
}
