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
    public CardPicture cardPicture;
    public CardTitle cardTitle;
    public CardDescription cardDescription;
    public Quality_Sprite cardContamination;
    public Quality_Sprite cardRarity;
    public Quality_Sprite cardType;


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
    public void ToggleCard(Sprite cardSprite, string name, string description, Sprite contamination, string rarity, string type)
    {

        // Populate baseball card

        // Get card preview picture
        cardPicture = gameObject.transform.Find("BaseballCard/CardPicture").GetComponent<CardPicture>();       
        cardPicture.m_Image.sprite = cardSprite;        
        
        // Get card item name
        cardTitle = gameObject.transform.Find("BaseballCard/CardTitle").GetComponent<CardTitle>();
        cardTitle.m_Title.text = name;     

        // Get card item description
        cardDescription = gameObject.transform.Find("BaseballCard/CardDescription").GetComponent<CardDescription>();
        cardDescription.m_Description.text = description;

        // Get card contamination
        cardContamination = gameObject.transform.Find("BaseballCard/Contamination").GetComponent<Quality_Sprite>();
        cardContamination.m_Quality.sprite = contamination;

        // Get card rarity
        cardRarity = gameObject.transform.Find("BaseballCard/Rarity").GetComponent<Quality_Sprite>();
        cardRarity.m_Quality.sprite = Resources.Load<Sprite>(rarity);

        // Get card type
        cardType = gameObject.transform.Find("BaseballCard/Type").GetComponent<Quality_Sprite>();
        cardType.m_Quality.sprite = Resources.Load<Sprite>(type);

        // Show baseball card
        ApparateCard();
    }

    public void DisapparateCard()
    {
        BaseballCard.SetActive(false);
        inventoryHandler.UpdateInventoryUI();
        Time.timeScale = 0f;
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
