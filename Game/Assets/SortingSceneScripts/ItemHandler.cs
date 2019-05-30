using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> items = new List<GameObject>();
    public SceneSystem sceneSystem;
    public PlayerController player;
    public int curItem = 1;
    public bool changeItem = false;
    public bool playPickupAnimation = false;
    Vector3 itemStartPos;
        int itemScale = 0;

    void Start()
    {   
        foreach (Transform x in transform)
        {
            items.Add(x.gameObject);
        }

        items[0].SetActive(true);
        itemStartPos = items[0].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (playPickupAnimation)
        {
            if (itemScale < 30)
            {
                // Make the item grow in size (to give appearance of
                // highlighting it) before allowing character to collect it
                items[curItem-1].transform.localScale += new Vector3(0.01F, 0.01f, 0f);

                // Make the item ascend in the y-axis (to give appearance of
                // highlighting it) before allowing character to collect it
                items[curItem - 1].transform.position += new Vector3(0.0F, 0.4f, 0.0f);

                // Increases scale variable so item can only expand 20 times,
                // before shrinking and descending (see else statement below)
                itemScale++;
            }

            else
            {
                // Make the item descend in the y-axis (after highlighting it)
                // closer to the character before allowing character to collect it;
                // gives appearance that item is falling into backpack
                items[curItem - 1].transform.position = Vector3.MoveTowards(items[curItem - 1].transform.position, player.transform.position, 1.0f * 2.90f);

                // Make the item shrink in scale (after highlighting it)
                // before allowing character to collect it; gives appearance
                // that item is shrinking into backpack
                if (items[curItem - 1].transform.localScale.x > 0.04f)
                {
                    items[curItem-1].transform.localScale += new Vector3(-0.02F, -0.02f, 0f);
                }

                // Checks if distance between item and player is negligible;
                // appearance of item does not matter at that point, so
                // changes item scale to zero before allowing character
                // to collect it
                if (Vector3.Distance(items[curItem - 1].transform.position, player.transform.position) < 0.4f)
                {
                   // Debug.Log("end");
                    items[curItem-1].SetActive(false);
                    itemScale = 0;
                }
            }

        }


        if (changeItem == true && curItem <= items.Count - 1)
        {
            Debug.Log("cureitem" + curItem);
            Debug.Log("itemCOunt" + items.Count);
            items[curItem - 1].SetActive(false);

            // items[curItem - 1].SetActive(false);
            items[curItem].SetActive(true);
            curItem = curItem + 1;
            changeItem = false;
            playPickupAnimation = false;
        } else if (changeItem == true && !(curItem <= items.Count - 1)){
            sceneSystem.winPopup.SetActive(true);
        }
    }

}
