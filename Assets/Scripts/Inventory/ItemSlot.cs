using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private int slotIndex;
    public int SlotIndex {get => slotIndex; set => slotIndex = value;}
    public ItemView CurrentView { get; set; }

    public void OnDrop(PointerEventData eventData)
    {
        ItemView draggedItem = eventData.pointerDrag.GetComponent<ItemView>();
        ItemSlot originalSlot = draggedItem.OriginalParent;
        if (CurrentView != null)
        {
            CurrentView.transform.SetParent(originalSlot.transform);
            CurrentView.transform.localPosition = Vector3.zero;

            originalSlot.CurrentView = CurrentView;
            CurrentView.OriginalParent = originalSlot;
            InventoryController.Instance.SetItem(originalSlot.SlotIndex, CurrentView.CurrentData);
        }

        CurrentView = draggedItem;
        CurrentView.transform.SetParent(transform);
        CurrentView.transform.localPosition = Vector3.zero;
        CurrentView.OriginalParent = this;

        InventoryController.Instance.SetItem(SlotIndex, CurrentView.CurrentData);
    }
}
