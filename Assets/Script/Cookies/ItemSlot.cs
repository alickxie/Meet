using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    int count;
    public List<GameObject> ItemImages;
    [SerializeField] private arrangeComplete arrangeComplete1;

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
            arrangeComplete1.countPlus();

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
        }
    }
}
