using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] public ItemSO itemData;
    [SerializeField] private GameManagerSO gameManager;
    public void Interact()
    {
        InventoryController.Instance.AddItem(new ItemData(itemData));
        Destroy(gameObject);
    }
}
