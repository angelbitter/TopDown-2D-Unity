using UnityEngine;

public class Item : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemSO itemData;
    [SerializeField] private GameManagerSO gameManager;
    [SerializeField] private Canvas endCanvas;
    public void Interact()
    {
        gameManager.Inventory.AddItem(itemData);
        Destroy(gameObject);

        if(itemData.name.Equals("Trophy"))
        {
            GameManager.Instance.EndGame(endCanvas);
        }
    }
}
