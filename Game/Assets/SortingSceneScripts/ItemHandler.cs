using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> items = new List<GameObject>();
    public int curItem = 0;
    public bool changeItem = false;
    void Start()
    {
        foreach (Transform x in transform)
        {
            items.Add(x.gameObject);
        }
       
       
    }

    // Update is called once per frame
    void Update()
    {
        if (curItem <= items.Count - 1)
        {
            items[curItem].SetActive(true);
        }
    }
}
