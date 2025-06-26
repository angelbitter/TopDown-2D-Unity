using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private ItemSO[] testItems;
    public static InventoryController Instance { get; private set; }
    private List<ItemData> items = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddItem(ItemData itemData)
    {
        int index = items.FindIndex(i => i.id == itemData.id);
        if (index >= 0)
        {
            items[index].amount += itemData.amount;
        }
        else
        {
            items.Add(itemData);
        }
    }
    [ContextMenu("Generate Items")]
    public void InitContent()
    {
        ItemData item = new ItemData(testItems[Random.Range(0, testItems.Length)]);
        items.Add(item);
    }
    
    public void SetItem(int index, ItemData itemData)
    {
        items[index] = itemData;
    }
    public ItemData GetItem(int index)
    {
        return items[index];
    }
}
