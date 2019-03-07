using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ItemDatabase : Item
{
    private List<Item> database = new List<Item>();
    private Item item = new Item();

    // Start is called before the first frame update
    void Start()
    {
        /*
        string path;
        string jsonString;

        path = Application.streamingAssetsPath + "/FlavorTexts.json";
        jsonString = File.ReadAllText(path);
        item = JsonUtility.FromJson<Item>(jsonString);
        Debug.Log(item);
        */

        /*
        itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/FlavorTexts.json"));
        string json = JsonUtility.ToJson(itemData);
        JsonUtility.FromJson<>(json);
        */
    }

    void ConstructItemDatabase()
    {
        /*
        for (int i = 0; i < itemData.Count; i++)
        {
            database.Add(new Item((int)itemData[i]["id"], )
        }
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
