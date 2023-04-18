using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OvenButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public GameObject oven;
    public Sprite coldSprite;
    public Sprite warmSprite;
    public Sprite hotSprite;
    public GameObject tempSlider;
    public Image onOffsign;
    public Sprite onSprite;
    public Sprite offSprite;
    public ProgressSlider progressSlider;
    // [SerializeField] Image ProgressCircle;
    bool isCooking;
    bool isPressing;
    bool increaseing;
    float tempNum = 0f;

    void Start()
    {
    }

    void Update()
    {
        // if (isPressing)
        // {
        //     this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -203);
        //     ProgressCircle.fillAmount += Time.deltaTime / 2;
        // }
        // else
        // {
        //     this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -188);
        //     if (ProgressCircle.fillAmount > 0)
        //     {
        //         ProgressCircle.fillAmount -= Time.deltaTime / 3;
        //         isCooking = true;
        //     }
        //     else
        //     {
        //         isCooking = false;
        //     }
        // }

        if (isPressing)
        {
            this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -203);
            isCooking = true;
        }
        else
        {
            this.gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -188);
            isCooking = false;
        }

        if (isCooking)
        {
            // make onOffsign sprite to onSprite
            onOffsign.sprite = onSprite;
            onOffsign.color = new Color(1, 1, 1, 1);

            if (progressSlider.GetProgress() < 0.7f)
            {
                oven.GetComponent<Image>().sprite = hotSprite;
            }
            if (progressSlider.GetProgress() > 0.7f)
            {
                oven.GetComponent<Image>().sprite = warmSprite;
            }

            increaseing = true;
        }
        else
        {
            StartCoroutine(coolDownWait());
        }

        if (increaseing)
        {
            tempNum += Time.deltaTime / 10;
            tempSlider.GetComponent<ProgressSlider>().UpdateProgress(tempNum);
        }
    }

    IEnumerator coolDownWait()
    {
        yield return new WaitForSeconds(2f);
        increaseing = false;

        if (!isPressing)
        {
            onOffsign.sprite = offSprite;
            onOffsign.color = new Color(0.89f, 0.89f, 0.89f, 1);
            oven.GetComponent<Image>().sprite = coldSprite;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("Pointer Down");
        isPressing = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Debug.Log("Pointer Up");
        isPressing = false;
    }

}
