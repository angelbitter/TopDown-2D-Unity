using UnityEngine;

public class PlayerItemHandler : MonoBehaviour
{
    
    [SerializeField] private Transform itemPosition;
    [SerializeField] private Item itemInHand;
    public void SetSelectedItem(ItemSO item)
    {
        if (itemInHand != null)
        {
            itemInHand = null;
            itemPosition.gameObject.SetActive(false);
        }
        itemInHand.itemData = item;
        if (itemInHand != null)
        {
            itemPosition.GetComponent<SpriteRenderer>().sprite = item.icon;
            itemPosition.gameObject.SetActive(true);
        }
    }
}
