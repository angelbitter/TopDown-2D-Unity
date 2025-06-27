using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    [SerializeField] private ItemSO[] testItems;
    public static InventoryController Instance { get; private set; }
    public List<ItemData> Items { get; } = new();

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
        int index = Items.FindIndex(i => i.id == itemData.id);
        if (index >= 0)
        {
            Items[index].amount++;
        }
        else
        {
            Items.Add(itemData);
        }
    }
    [ContextMenu("Generate Items")]
    public void InitContent()
    {
        ItemData item = new ItemData(testItems[Random.Range(0, testItems.Length)]);
        Items.Add(item);
    }
    
    public void SetItem(int index, ItemData itemData)
    {
        Items[index] = itemData;
    }
    public ItemData GetItem(int index)
    {
        return Items[index];
    }
}
