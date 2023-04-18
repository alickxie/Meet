using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BagItemSlot : MonoBehaviour, IDropHandler
{

    public List<GameObject> bags;
    public List<GameObject> stickers;
    public List<Sprite> cookieBags;
    public List<Sprite> bagStickers;
    public GameObject stickerOnBag;
    public GameObject nextButton;
    public GameObject bagedCookies;
    public GameObject cookies;

    bool droped;

    void Start()
    {
        nextButton.SetActive(false);
        bagedCookies.SetActive(false);
        stickerOnBag.SetActive(false);
    }

    void Update()
    {
        if (droped)
        {
            nextButton.GetComponent<CanvasGroup>().alpha += Time.deltaTime;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            nextButton.SetActive(true);
            droped = true;
            bagedCookies.SetActive(true);
            cookies.SetActive(false);

            if (eventData.pointerDrag.name == "bag1")
            {
                bagedCookies.GetComponent<Image>().sprite = cookieBags[0];
                eventData.pointerDrag.GetComponent<DragDrop>().retrive = true;
                bags[0].GetComponent<Image>().enabled = false;
                bags[1].GetComponent<Image>().enabled = true;
                bags[2].GetComponent<Image>().enabled = true;
                bags[3].GetComponent<Image>().enabled = true;
            }

            if (eventData.pointerDrag.name == "bag2")
            {
                bagedCookies.GetComponent<Image>().sprite = cookieBags[1];
                eventData.pointerDrag.GetComponent<DragDrop>().retrive = true;
                bags[0].GetComponent<Image>().enabled = true;
                bags[1].GetComponent<Image>().enabled = false;
                bags[2].GetComponent<Image>().enabled = true;
                bags[3].GetComponent<Image>().enabled = true;
            }

            if (eventData.pointerDrag.name == "bag3")
            {
                bagedCookies.GetComponent<Image>().sprite = cookieBags[2];
                eventData.pointerDrag.GetComponent<DragDrop>().retrive = true;
                bags[0].GetComponent<Image>().enabled = true;
                bags[1].GetComponent<Image>().enabled = true;
                bags[2].GetComponent<Image>().enabled = false;
                bags[3].GetComponent<Image>().enabled = true;
            }

            if (eventData.pointerDrag.name == "bag4")
            {
                bagedCookies.GetComponent<Image>().sprite = cookieBags[3];
                eventData.pointerDrag.GetComponent<DragDrop>().retrive = true;
                bags[0].GetComponent<Image>().enabled = true;
                bags[1].GetComponent<Image>().enabled = true;
                bags[2].GetComponent<Image>().enabled = true;
                bags[3].GetComponent<Image>().enabled = false;
            }

            if (eventData.pointerDrag.name == "sticker1" || eventData.pointerDrag.name == "sticker2" || 
            eventData.pointerDrag.name == "sticker3" || eventData.pointerDrag.name == "sticker4")
            {
                stickerOnBag.SetActive(true);
            }

            if (eventData.pointerDrag.name == "sticker1")
            {
                stickerOnBag.GetComponent<Image>().sprite = bagStickers[0];
                eventData.pointerDrag.GetComponent<DragDrop>().retrive = true;
                stickers[0].GetComponent<Image>().enabled = false;
                stickers[1].GetComponent<Image>().enabled = true;
                stickers[2].GetComponent<Image>().enabled = true;
                stickers[3].GetComponent<Image>().enabled = true;
                stickers[4].GetComponent<Image>().enabled = true;
                stickers[5].GetComponent<Image>().enabled = true;
            }

            if (eventData.pointerDrag.name == "sticker2")
            {
                stickerOnBag.GetComponent<Image>().sprite = bagStickers[1];
                eventData.pointerDrag.GetComponent<DragDrop>().retrive = true;
                stickers[0].GetComponent<Image>().enabled = true;
                stickers[1].GetComponent<Image>().enabled = false;
                stickers[2].GetComponent<Image>().enabled = true;
                stickers[3].GetComponent<Image>().enabled = true;
                stickers[4].GetComponent<Image>().enabled = true;
                stickers[5].GetComponent<Image>().enabled = true;
            }

            if (eventData.pointerDrag.name == "sticker3")
            {
                stickerOnBag.GetComponent<Image>().sprite = bagStickers[2];
                eventData.pointerDrag.GetComponent<DragDrop>().retrive = true;
                stickers[0].GetComponent<Image>().enabled = true;
                stickers[1].GetComponent<Image>().enabled = true;
                stickers[2].GetComponent<Image>().enabled = false;
                stickers[3].GetComponent<Image>().enabled = true;
                stickers[4].GetComponent<Image>().enabled = true;
                stickers[5].GetComponent<Image>().enabled = true;
            }

            if (eventData.pointerDrag.name == "sticker4")
            {
                stickerOnBag.GetComponent<Image>().sprite = bagStickers[3];
                eventData.pointerDrag.GetComponent<DragDrop>().retrive = true;
                stickers[0].GetComponent<Image>().enabled = true;
                stickers[1].GetComponent<Image>().enabled = true;
                stickers[2].GetComponent<Image>().enabled = true;
                stickers[3].GetComponent<Image>().enabled = false;
                stickers[4].GetComponent<Image>().enabled = true;
                stickers[5].GetComponent<Image>().enabled = true;
            }

            if (eventData.pointerDrag.name == "sticker5")
            {
                stickerOnBag.GetComponent<Image>().sprite = bagStickers[4];
                eventData.pointerDrag.GetComponent<DragDrop>().retrive = true;
                stickers[0].GetComponent<Image>().enabled = true;
                stickers[1].GetComponent<Image>().enabled = true;
                stickers[2].GetComponent<Image>().enabled = true;
                stickers[3].GetComponent<Image>().enabled = true;
                stickers[4].GetComponent<Image>().enabled = false;
                stickers[5].GetComponent<Image>().enabled = true;
            }

            if (eventData.pointerDrag.name == "sticker6")
            {
                stickerOnBag.GetComponent<Image>().sprite = bagStickers[5];
                eventData.pointerDrag.GetComponent<DragDrop>().retrive = true;
                stickers[0].GetComponent<Image>().enabled = true;
                stickers[1].GetComponent<Image>().enabled = true;
                stickers[2].GetComponent<Image>().enabled = true;
                stickers[3].GetComponent<Image>().enabled = true;
                stickers[4].GetComponent<Image>().enabled = true;
                stickers[5].GetComponent<Image>().enabled = false;
            }
        }
    }
}
