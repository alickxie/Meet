using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class newSlots : MonoBehaviour, IDropHandler
{

    private string itemImageName;
    private string itemSlotsName;

    // The correct item name
    public string ItemImageName;

    public bool isSlotsFilled = false;
    public bool turlyFilled = false;

    AudioSource DialNum;

    public Image rayCast;

    void Start()
    {
        DialNum = GameObject.Find("DialNum").GetComponent<AudioSource>();
        rayCast = this.gameObject.GetComponent<Image>();
    }

    void Update()
    {

    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null && !isSlotsFilled)
        {
            DialNum.Play();

            // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
            eventData.pointerDrag.GetComponent<Image>().raycastTarget = false;
            isSlotsFilled = true;
            if (eventData.pointerDrag.GetComponent<Image>().sprite.name == ItemImageName)
            {
                // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                eventData.pointerDrag.GetComponent<DragtoSlideNew>().isSnapped = true;
                turlyFilled = true;
            }
            itemImageName = eventData.pointerDrag.GetComponent<Image>().sprite.name;
            // itemSlotsName = gameObject.name;
            Debug.Log("Item Image Name: " + itemImageName);
        }
    }
}
