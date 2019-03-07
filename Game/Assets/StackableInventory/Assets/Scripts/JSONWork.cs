using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONWork : MonoBehaviour
{
    string path;
    string jsonString;
    
    void FetchItemByName(string name)
    {
        path = Application.streamingAssetsPath + "/FlavorTexts.json";
        jsonString = File.ReadAllText(path);
        /*
        for (int i = 0; i < ItemHolder.itemSlots.Length; i++)
        {

        }
        */
    }
}

[System.Serializable]
public class Items
{
    public string name;
    public string description;
    public SVGImage icon;
    public int price;
    public string type;
}
