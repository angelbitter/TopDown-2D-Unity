using UnityEngine;

public class Item : NonPersistenObject, IInteractable
{
    [SerializeField] public ItemSO itemData;

    private void Start()
    {
        if (GameManager.Instance.nonPersistentObjects.ContainsKey(uniqueId))
        {
            if (GameManager.Instance.nonPersistentObjects[uniqueId] == false)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            GameManager.Instance.nonPersistentObjects.Add(uniqueId, true);
        }
    }
    public void Interact()
    {
        InventoryController.Instance.AddItem(new ItemData(itemData));
        Destroy(gameObject);
        GameManager.Instance.nonPersistentObjects[uniqueId] = false;
    }
}
