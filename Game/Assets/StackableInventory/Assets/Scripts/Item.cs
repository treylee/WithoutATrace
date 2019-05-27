using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using UnityEngine.Analytics;
using Newtonsoft.Json.Linq;
using System.Linq;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName  { get; set; }
    public string itemDescription { get; set; }
    public Sprite icon { get; set; }
    public Sprite itemContamination { get; set; }
    public string itemRarity { get; set; }
    public string itemType { get; set; }
    public int currentStack = 1;
    public int maxStack { get; set; }

    public static explicit operator Item(GameObject v)
    {
        throw new NotImplementedException();
    }



    // Define all of item's properties
    // (not just title)
    public string GenerateTitle(string title)
    {
        // All the values that need to be generated

        string filePath = Application.streamingAssetsPath + "/ItemFlavors.json";
        Debug.Log("FILE: " + filePath);
        string wantedString = null;

        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            JArray flavors = JArray.Parse(dataAsJson);

            foreach (JObject entry in flavors.Children<JObject>())
            {
                // Check if object exists in database listing
                // all possible items
                JToken objectName = entry.SelectToken("itemName");
                if (string.Compare(objectName.ToString(), title) == 0)
                {
                    // Item exists
                    Debug.Log("here now");
                    this.itemName = objectName.ToString();
                    this.itemDescription = entry.SelectToken("itemDescription").ToString();
                    icon = Resources.Load<Sprite>(itemName);

                    bool isContaminated = (UnityEngine.Random.value > 0.5f);
                    if (isContaminated)
                    {
                        itemContamination = Resources.Load<Sprite>("Contaminated");
                    }
                    else
                    {
                        itemContamination = Resources.Load<Sprite>("Uncontaminated");
                    }

                    this.itemRarity = entry.SelectToken("itemRarity").ToString();
                    this.itemType = entry.SelectToken("itemType").ToString();
                    this.maxStack = System.Convert.ToInt32(entry.SelectToken("maxStack"));
                    break;
                }
            }
        }
        return wantedString;
    }
}
