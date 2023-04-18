using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragtoSlideNew : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;

    public bool isSnapped = false;
    public bool retrive = false;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 originPos;

    private Camera mainCamera;
    private Vector3 screenBounds;

    PresstoSlide presstoSlide;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originPos = rectTransform.position;

        mainCamera = Camera.main;

        screenBounds = new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z);
        screenBounds = mainCamera.ScreenToWorldPoint(screenBounds);

        presstoSlide = GameObject.Find("cat").GetComponent<PresstoSlide>();
    }

    void Update()
    {
        if (retrive)
        {
            rectTransform.position = originPos;
            retrive = false;
        }

        Vector3 viewPos = mainCamera.WorldToViewportPoint(transform.position);

        // The GameObject is out of screen space
        if (viewPos.x < 0 || viewPos.x > 1 || viewPos.y < 0 || viewPos.y > 1)
        {
            rectTransform.position = originPos;
            isSnapped = true;
            // wait for 1 second
            StartCoroutine(WaitForOneSecond());
        }
    }

    private void setCurrentLayerOnTop()
    {
        // set current gameobject on top child of it's parent
        transform.SetAsLastSibling();
    }

    IEnumerator WaitForOneSecond()
    {
        yield return new WaitForSeconds(1);
        isSnapped = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isSnapped)
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
            presstoSlide.allSlotRaycastOn();
            setCurrentLayerOnTop();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isSnapped)
        {
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        presstoSlide.allSlotRaycastOff();
        // if (!isSnapped)
        // {
        //     retrive = true;
        // }
    }

    public void OnDrop()
    {
        retrive = true;
    }
}
