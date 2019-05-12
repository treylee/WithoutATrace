using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item_Spawner : Item
{

    private int rand;
    public Sprite[] Sprite_Pic;
    public Sprite pic;
    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, Sprite_Pic.Length);
        GetComponent<SpriteRenderer>().sprite = Sprite_Pic[rand];
        //pic = GetComponent<SpriteRenderer>().sprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
