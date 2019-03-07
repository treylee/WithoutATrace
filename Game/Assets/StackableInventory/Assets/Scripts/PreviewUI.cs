using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PreviewUI : MonoBehaviour, IPointerClickHandler
{
    //private GameObject temp;
    public Image m_Image;
    //Set this in the Inspector
    public Sprite m_Sprite;
    protected GameObject temp;

    void Start()
    {
        //Fetch the Image from the GameObject
        m_Image = GetComponent<Image>();
    }


    /*
    public void OnDrop(PointerEventData eventData)
    {
        
            Debug.Log("happened");
            m_Sprite = eventData.pointerPress.gameObject.GetComponent<Image>().sprite;
            RefreshPreviewIcon();

    }
    */

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        m_Sprite = pointerEventData.pointerPress.gameObject.GetComponent<Image>().sprite;
        RefreshPreviewIcon();
        Debug.Log("Refreshed");
    }

    public void RefreshPreviewIcon()
    {
        m_Image.sprite = m_Sprite;
    }

    void Update()
    {
        RefreshPreviewIcon();
    }



    /*
    protected GameObject previewSprite;
    protected ItemHolder.ItemSlot droppedItemSlot;
    protected ItemHolder.PreviewSlot thisPreviewSlot;
    protected Image tempImage;

    protected GameObject grabbedObject;

    private InventoryHandler inventoryHandler;

    private Item thisItem;
    protected ItemHolder.ItemSlot thisItemSlot;

    protected virtual void Start()
    {
        inventoryHandler = InventoryHandler.instance;
        previewSprite = transform.GetChild(0).gameObject;
        previewSprite.SetActive(true);
    }

    public void OnDrop(PointerEventData eventData)
    {
        //GetComponent<CanvasGroup>().blocksRaycasts = true;
        thisItem = eventData.pointerDrag.GetComponent<Item>();

        if (thisItemSlot != null)
        {
            Debug.Log("slot found");
        }
        thisPreviewSlot.previewImage = thisItemSlot.item.icon;
        previewSprite.GetComponent<Image>().sprite = droppedItemSlot.item.icon;
        previewSprite.SetActive(true);
        RefreshPreview();
    }    

    public void RefreshPreview()
    {
        if (thisPreviewSlot.previewImage != null)
        {
            if (previewSprite.GetComponent<Image>().sprite != null)
            {
                Debug.Log("sprite not null");
            }
            previewSprite.SetActive(true);
        }
        else
        {
            previewSprite.SetActive(false);
        }
    }
    */
}
