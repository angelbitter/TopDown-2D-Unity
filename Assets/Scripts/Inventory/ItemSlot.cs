using UnityEngine;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private ItemView itemView;
    public ItemView CurrentView { get => itemView; }

    public void OnDrop(PointerEventData eventData)
    {
        if (itemView != null)
        {
            //intercambio
            Destroy(CurrentView.gameObject);
        }
        Transform newInfo = eventData.pointerDrag.transform;
        newInfo.SetParent(transform);
        newInfo.localPosition = Vector3.zero;
       

       /// Actualizar datos del inventory conrtroller
       /// 
    }
}
