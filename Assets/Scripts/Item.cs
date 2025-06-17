using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemSO itemData;
    [SerializeField] private GameManagerSO gameManager;
    public void Interact()
    {
        gameManager.Inventory.AddItem(itemData);
        Destroy(gameObject);
    }
}
