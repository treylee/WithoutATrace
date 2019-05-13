using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
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
    //private TextMeshProUGUI content;
    public Text title;

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
            /*
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            pos.z = 10.0f;
            transform.position = pos - offset;
            */

            /*
            Vector3 screenPoint = Input.mousePosition;
            screenPoint.z = 100.0f; //distance of the plane from the camera
            transform.position = Camera.main.ScreenToWorldPoint(screenPoint);
            */

            
            RectTransformUtility.ScreenPointToLocalPointInRectangle(transform as RectTransform, (Vector2)eventData.position, null, out localPosition);
            transform.position = transform.TransformPoint(localPosition) + offset;
            
            
            //transform.position.z = 10.0f;
            //transform.position += offset;
            
        }

        
        
    }

    float _doubleTapTimeD;

    public void OnPointerUp(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            isDragging = false;
            transform.SetParent(originalParent);
            transform.localPosition = Vector3.zero;
            offset = Vector3.zero;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
            //thisPreviewSlot.previewImage = draggedImage;
            draggedImage = eventData.pointerDrag.GetComponent<ItemDragHandler>().GetItemSlot().item.icon;
            Debug.Log("ITEM: " + eventData.pointerDrag.GetComponent<ItemDragHandler>().GetItemSlot().item.itemName);
            FindObjectOfType<PreviewUI>().m_Image.sprite = draggedImage;
            FindObjectOfType<PreviewUI>().m_Sprite = draggedImage;
            //Debug.Log("ITEM: " + item.itemName);
            title = FindObjectOfType<PreviewTitle>().m_Title;
            title.text = eventData.pointerDrag.GetComponent<ItemDragHandler>().GetItemSlot().item.itemName;
            //Debug.Log("name: " + eventData.pointerDrag.GetComponent<ItemDragHandler>().GetItemSlot().item.itemName);
            //Debug.Log("description: " + eventData.pointerDrag.GetComponent<ItemDragHandler>().GetItemSlot().item.itemDescription);

            bool doubleTapD = false;

            #region doubleTapD

            if (Input.GetMouseButtonUp(0))
            {
                if (Time.time < _doubleTapTimeD + .3f)
                {
                    doubleTapD = true;
                    Debug.Log("tapped");
                }
                _doubleTapTimeD = Time.time;
            }

            #endregion

            if (doubleTapD)
            {
                Debug.Log("double");
                gameObject.GetComponent<ItemDragHandler>().gameObject.SetActive(false);
                FindObjectOfType<Baseball_Panel>().ToggleCard(itemSlot.item.icon, itemSlot.item.itemName, itemSlot.item.itemDescription);
                //gameObject.GetComponent<ItemDragHandler>().gameObject.SetActive(true);

                //gameObject.GetComponent<ItemHolder>();
            }

        }
    }

    protected virtual void DropFromSlot()
    {
        // Find the slot for this drag handler
        // and drops the item
    }




}
