using UnityEngine;
using UnityEngine.EventSystems;

public class DragtoSlide : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;

    public bool isSnapped = false;
    public bool retrive = false;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 originPos;


    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originPos = rectTransform.position;
    }

    void Update()
    {
        if (retrive)
        {
            rectTransform.position = originPos;
            retrive = false;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (!isSnapped)
        {
            canvasGroup.alpha = .6f;
            canvasGroup.blocksRaycasts = false;
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
    }
}
