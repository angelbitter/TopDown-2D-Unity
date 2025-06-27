using UnityEngine.UI;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using System;

public class ItemView : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text itemName;
    [SerializeField] private TMP_Text itemAmount;

    public ItemData CurrentData { get; set; }
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    private RectTransform rectTransform;
    private Vector3 originalPosition;
    public ItemSlot OriginalParent { get; set; }

    private void Awake()
    {
        canvas = transform.root.GetComponent<Canvas>();
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;
        OriginalParent = transform.parent.GetComponent<ItemSlot>();
    }
    public void SetItem(ItemData itemData)
    {
        CurrentData = itemData;
        icon.sprite = itemData.itemSprite;
        itemName.text = itemData.itemName;
        itemAmount.text = "x " + itemData.amount.ToString();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        rectTransform.SetParent(canvas.transform);
        canvasGroup.blocksRaycasts = false;
        canvasGroup.alpha = 0.3f;
    }
    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1f;
        if (rectTransform.parent == canvas.transform)
        {
            transform.SetParent(OriginalParent.transform);
            rectTransform.anchoredPosition = originalPosition;
        }
    }
}
