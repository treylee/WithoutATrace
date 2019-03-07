using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


//File implements interfaces for inventory dragging and swapping

public class ItemDragHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    // Item that is being dragged
    public Item item;

    [SerializeField]
    private Transform itemHolderParent;


    protected int slotIndex;
    protected ItemHolder.ItemSlot itemSlot;
    protected ItemHolder.PreviewSlot thisPreviewSlot;

    private Sprite draggedImage;

    // Stores parent position when dragging, so it can snap back to it if let go
    private Transform originalParent;
    // Keeps track of drag status
    private bool isDragging;

    // For tracking item movement
    //private Vector3 mousePosition;
    private Vector3 pos;
    private Vector3 offset;
    //to deal with z offset for UI
    private Vector2 localPosition;

    public ItemHolder.ItemSlot GetItemSlot()
    {
        return itemSlot;
    }
    

    protected virtual void Start()
    {
        slotIndex = transform.parent.GetSiblingIndex();
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        isDragging = true;
        originalParent = transform.parent;
        transform.SetParent(itemHolderParent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
        

        //offset = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, (Vector2)eventData.position, null, out localPosition);
        offset = transform.position - transform.TransformPoint(localPosition);
        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            //pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //transform.position = pos - offset;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, (Vector2)eventData.position, null, out localPosition);
            transform.position = transform.TransformPoint(localPosition) + offset;
        }

        /*
        if (Inventory.instance.itemList[originalParent.transform.GetSiblingIndex()] != null && eventData.button == PointerEventData.InputButton.Left)
        {
            //Shouldn't need the two lines below, but keeping it in case of problems with drag later
            //transform.position = Input.mousePosition;
            //mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
            
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            transform.position = pos - offset;
            
        }
        */
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isDragging = false;
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            offset = Vector3.zero;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            thisPreviewSlot.previewImage = draggedImage;
            draggedImage = eventData.pointerDrag.GetComponent<ItemDragHandler>().GetItemSlot().item.icon;
            FindObjectOfType<PreviewUI>().m_Image.sprite = draggedImage;
            FindObjectOfType<PreviewUI>().m_Sprite = draggedImage;
            Debug.Log("got here");
            
            string path;
            string jsonString;

            path = Application.streamingAssetsPath + "/FlavorTexts.json";
            jsonString = File.ReadAllText(path);
            //Item CollectedItem = JsonConvert.DeserializeObject(jsonString);
        
        }
    }

    protected virtual void DropFromSlot()
    {
        // Find the slot for this drag handler
        // and drops the item
    }
}
