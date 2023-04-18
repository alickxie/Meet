using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Canvas canvas;

    public bool isSnapped = false;
    public bool retrive = false;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector3 originPos;

    

    private void Awake()
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

    private void setCurrentLayerOnTop()
    {
        // set current gameobject on top child of it's parent
        transform.SetAsLastSibling();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        isSnapped = false;
        transform.SetAsLastSibling();
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
    }
}
