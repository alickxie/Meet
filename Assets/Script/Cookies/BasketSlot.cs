using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class BasketSlot : MonoBehaviour, IDropHandler
{
    int count;
    public List<GameObject> ItemImages;
    public GameObject processButton;

    void Start()
    {
        foreach (GameObject item in ItemImages)
        {
            item.SetActive(false);
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Destroy(eventData.pointerDrag);
            count++;

            // how to get eventData.pointerDrag's name

            if (eventData.pointerDrag.name == "NumberItems_1")
            {
                ItemImages[0].SetActive(true);
            }

            if (eventData.pointerDrag.name == "NumberItems_2")
            {
                ItemImages[1].SetActive(true);
            }

            if (eventData.pointerDrag.name == "NumberItems_3")
            {
                ItemImages[2].SetActive(true);
            }

            if (eventData.pointerDrag.name == "NumberItems_4")
            {
                ItemImages[3].SetActive(true);
            }

            if (eventData.pointerDrag.name == "NumberItems_5")
            {
                ItemImages[4].SetActive(true);
            }

            if (eventData.pointerDrag.name == "NumberItems_6")
            {
                ItemImages[5].SetActive(true);
            }

            if (eventData.pointerDrag.name == "NumberItems_7")
            {
                ItemImages[6].SetActive(true);
            }

            if (eventData.pointerDrag.name == "NumberItems_8")
            {
                ItemImages[7].SetActive(true);
                processButton.SetActive(true);
            }

            if (eventData.pointerDrag.name == "NumberItems_9")
            {
                ItemImages[8].SetActive(true);
            }
        }
    }
}
