using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CookieTools : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    public GameObject dough;
    private CanvasGroup canvasGroup;
    private Vector3 originPos;

    public List<Sprite> images;

    public GameObject progressSlider;
    float progressNum = 0;
    int singleton = 0;

    public TaskChange taskChange;

    public Animator RabbitAnimator;
    float tempDistance;
    public bool isDough = false;
    Animator CookieDoughAnimator;

    private Camera mainCamera;
    private Vector3 screenBounds;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originPos = rectTransform.position;

        if (isDough)
        {
            CookieDoughAnimator = GameObject.Find("CookieDough").GetComponent<Animator>();
            CookieDoughAnimator.SetBool("phase2", false);
            CookieDoughAnimator.SetBool("phase3", false);
        }

        mainCamera = Camera.main;

        screenBounds = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);
        screenBounds = mainCamera.ScreenToWorldPoint(screenBounds);
    }

    void Update()
    {
        // Change the dough images
        if (progressSlider.GetComponent<ProgressSlider>().GetProgress() >= 0.33f && progressSlider.GetComponent<ProgressSlider>().GetProgress() < 0.66f)
        {
            if (!isDough)
            {
                dough.GetComponent<Image>().sprite = images[0];
            }
            else
            {
                CookieDoughAnimator.SetBool("phase2", true);
            }
        }
        if (progressSlider.GetComponent<ProgressSlider>().GetProgress() >= 0.66f)
        {
            if (!isDough)
            {
                dough.GetComponent<Image>().sprite = images[1];
            }
            else
            {
                CookieDoughAnimator.SetBool("phase2", false);
                CookieDoughAnimator.SetBool("phase3", true);
            }
        }

        if (progressSlider.GetComponent<ProgressSlider>().GetProgress() >= 1)
        {
            if (singleton == 0)
            {
                taskChange.ShiftLeft();
                singleton++;
            }
        }

        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        // if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        // {
        //     // The GameObject is out of screen space
        //     transform.position = new Vector3(Random.Range(0, 1), -2.6f, 0);
        // }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // get the total distance the mouse has moved
        if (IsOverlapping(rectTransform, dough.GetComponent<RectTransform>()))
        {
            float distance = Vector3.Distance(rectTransform.position, originPos);
            if (distance == tempDistance)
            {
                RabbitAnimator.SetBool("isMaking", false);
                if (isDough){CookieDoughAnimator.SetBool("isMoving", false);}
            }
            else
            {
                if (isDough){CookieDoughAnimator.SetBool("isMoving", true);}
                RabbitAnimator.SetBool("isMaking", true);
            }
            tempDistance = distance;

            progressNum += distance / 1200;
            // update the progress slider
            progressSlider.GetComponent<ProgressSlider>().UpdateProgress(progressNum);
        }

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        RabbitAnimator.SetBool("isMaking", false);
        if (isDough){CookieDoughAnimator.SetBool("isMoving", false);}
        // canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }

    // compare if the rect transform of tool1 is overlapped with the rect transform of Plate1
    public bool IsOverlapping(RectTransform rectTransform1, RectTransform rectTransform2)
    {
        Vector3[] corners1 = new Vector3[4];
        Vector3[] corners2 = new Vector3[4];
        rectTransform1.GetWorldCorners(corners1);
        rectTransform2.GetWorldCorners(corners2);

        if (corners1[0].x > corners2[2].x || corners1[2].x < corners2[0].x || corners1[0].y > corners2[2].y || corners1[2].y < corners2[0].y)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
