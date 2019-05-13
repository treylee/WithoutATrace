using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Baseball_Panel : MonoBehaviour
{
    // Flag indicating whether game is paused
    public static bool isClosed = true;

    // Baseball Panel that script is attached to
    public GameObject BaseballCard;
    public PreviewPicture cardPicture;

    public CardTitle cardTitle;
    public CardDescription cardDescription;

    private InventoryHandler inventoryHandler;
    //public

    /*
    [System.Serializable]
    public class PreviewPicture
    {
        public Sprite cardImage;

        public PreviewPicture(Sprite setimage)
        {
            cardImage = setimage;
        }

        public void SetNewPreview(Sprite newImage)
        {
            cardImage = newImage;
        }
    }
    */

    float _doubleTapTimeD;

    void Start()
    {
        BaseballCard.SetActive(false);
        inventoryHandler = FindObjectOfType<InventoryHandler>();
        //DisapparateCard();
    }

    // Update is called once per frame
    public void ToggleCard(Sprite cardSprite, string name, string description)
    {

        // Populate baseball card with image
        Debug.Log("NAME: " + name);
        Debug.Log("DESCRIPTION: " + description);

        // Get card preview picture
        cardPicture = gameObject.transform.Find("BaseballCard/CardPicture/PreviewPicture").GetComponent<PreviewPicture>();
        cardPicture.m_Image.sprite = cardSprite;

        // Get card item name
        cardTitle = gameObject.transform.Find("BaseballCard/CardName/Text").GetComponent<CardTitle>();
        cardTitle.m_Title.text = name;

        // Get card item description
        cardDescription = gameObject.transform.Find("BaseballCard/CardDescription/Text").GetComponent<CardDescription>();
        cardDescription.m_Description.text = description;

        // Show baseball card
        ApparateCard();
    }

    public void DisapparateCard()
    {
        //Debug.Log("sensing");
        BaseballCard.SetActive(false);
        inventoryHandler.UpdateInventoryUI();
        Time.timeScale = 1f;
        isClosed = false;
    }

    public void ApparateCard()
    {
        BaseballCard.SetActive(true);
        inventoryHandler.UpdateInventoryUI();
        Time.timeScale = 0f;
        isClosed = true;
    }
}
