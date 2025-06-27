using UnityEngine;

public class Item : NonPersistenObject, IInteractable
{
    [SerializeField] public ItemSO itemData;
    [SerializeField] private Canvas endCanvas;

    private void Start()
    {
        if (GameManager.Instance.NonPersistentObjects.ContainsKey(uniqueId))
        {
            if (GameManager.Instance.NonPersistentObjects[uniqueId] == false)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            GameManager.Instance.NonPersistentObjects.Add(uniqueId, true);
        }
    }
    public void Interact()
    {
        InventoryController.Instance.AddItem(new ItemData(itemData));
        Destroy(gameObject);
        GameManager.Instance.NonPersistentObjects[uniqueId] = false;

        if(itemData.name.Equals("Trophy"))
        {
            GameManager.Instance.EndGame(endCanvas);
        }
    }
}
