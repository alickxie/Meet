using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Slots : MonoBehaviour, IDropHandler
{

    private string itemImageName;
    private string itemSlotsName;

    // The correct item name
    public string ItemImageName;

    public bool isSlotsFilled = false;

    void Update()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            isSlotsFilled = true;
            if (eventData.pointerDrag.GetComponent<Image>().sprite.name == ItemImageName)
            {
                // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<DragtoSlide>().isSnapped = true;
            }
            itemImageName = eventData.pointerDrag.GetComponent<Image>().sprite.name;
            // itemSlotsName = gameObject.name;
            Debug.Log("Item Image Name: " + itemImageName);
        }
    }
}
