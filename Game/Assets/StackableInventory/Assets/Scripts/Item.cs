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
    public int itemPrice { get; set; }
    public bool itemContamination { get; set; }
    public ItemTypes itemType = ItemTypes.Undefined;
    public int currentStack = 1;
    public int maxStack = 1;
    
    public static explicit operator Item(GameObject v)
    {
        throw new NotImplementedException();
    }


    // Generates a random item (in string form for JSON) 
    // to be placed on top of collider in level design
    public void MakeItem()
    {
        Debug.Log("started");
        string filePath = Application.streamingAssetsPath + "/ItemFlavors.json";
        string wantedString = null;

        if (File.Exists(filePath))
        {
            Debug.Log("reached");
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            JArray flavors = JArray.Parse(dataAsJson);

            // Holds number of flavor texts
            int flavorCount = flavors.Children<JObject>().Count();

            // For generating contamination property
            bool isContaminated = (UnityEngine.Random.value > 0.5f);

            // Index for generating name, description, and type properties
            int itemNum = UnityEngine.Random.Range(0, flavorCount);

            // Read name, description, and type using index
            itemName = flavors[itemNum].SelectToken("itemName").ToString();
            Debug.Log("name: " + flavors[itemNum].SelectToken("itemName").ToString());
            Debug.Log("description: " + flavors[itemNum].SelectToken("itemDescription").ToString());
            itemDescription = flavors[itemNum].SelectToken("itemDescription").ToString();
            //itemType = (ItemTypes)int.Parse(flavors[itemNum].SelectToken("itemDescription").ToString());
            icon = Resources.Load<Sprite>(itemName);
            //Debug.Log("GETNAME: " + GetComponent<Item_Spawner>().pic.name);
            

            //Debug.Log("name: " + itemName);
            //Debug.Log("description: " + itemDescription);
            //Debug.Log("itemType" + itemType);
            //item.itemContamination = 


        }

    }




    public string GenerateTitle(string title)
    {

        // All the values that need to be generated
        string name;
        string description;
        //string iconPath;
        //string price;
        //string contamination;
        string type;

        string filePath = Application.streamingAssetsPath + "/ItemFlavors.json";
        Debug.Log("FILE: " + filePath);
        string wantedString = null;





        if (File.Exists(filePath))
        {
            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath);
            JArray flavors = JArray.Parse(dataAsJson);

            int i = flavors.Children<JObject>().Count();
            //Debug.Log("i: " + i);

            //Debug.Log("iteminfo:" + dataAsJson);

            //JObject wantedItem = flavors.SelectObject(title);
            //JToken wantedText = flavors[2].SelectToken("itemName");
            //Debug.Log(wantedText);
            //int index = flavors.IndexOf(title);
            //Debug.Log("index: " + index);

            //Debug.Log("token: " + flavors[1].SelectToken("itemName").ToString());
            Debug.Log("title: " + title);


            foreach (JObject entry in flavors.Children<JObject>())
            {
                JToken objectName = entry.SelectToken("itemName");
                Debug.Log("objectName: " + objectName.ToString());
                if (string.Compare(objectName.ToString(), title) == 0)
                {

                    wantedString = objectName.ToString();
                    this.itemName = wantedString;
                    this.itemDescription = entry.SelectToken("itemDescription").ToString();
                    
                    Debug.Log("wantedString: " + wantedString);
                    Debug.Log(itemDescription);

                    icon = Resources.Load<Sprite>(itemName);
                    break;
                }
                
                /*
                foreach (JProperty p in o.Properties())
                {

                    string pname = p.Name;
                    string value = (string)p.Value;
                    Debug.Log(pname + " -- " + value);
                }
                */

            }
            



            //Flavor[] itemFlavors = JSONProcessor.ToObject<Flavor>(dataAsJson);
            //JsonConverter[] x;
            //List<Flavor> flavor = JsonConvert.DeserializeObject<List<Flavor>>(dataAsJson);
            //Debug.Log(flavor[0]);

            //List<Flavor> list = JsonConvert.DeserializeObject<List<Flavor>>(dataAsJson);

            //Flavor alice = JsonUtility.FromJson<Flavor>(dataAsJson);
            //Debug.Log(alice.flav[0]);


            //Debug.Log(list[0]);

            // Retrieve the allRoundData property of
        }

        return wantedString;


        // Assigns random values
        //bool Boolean = (UnityEngine.Random.value > 0.5f);
        //bool itemNum = UnityEngine.Random.Range(0, UnityEngine.Object.ItemFlavors(jsonArray).length);

        //string path = "Assets/Scripts/ItemFlavors.json";

        //Read the text from directly from the test.txt file
        //StreamReader reader = new StreamReader(path);
        //Debug.Log(Gender.ReadToEnd());
        //reader.Close();


        /*
        randomly generate type
        randomly generate the name based on the type, set description 
        to prewritten string that corresponds with name, 
        and sprite to path that corresponds to name
        name and description and sprite and type must correspond
        price and contamination can be random
        contamination is a bool
        price is some random number of coi
        */


    }


}