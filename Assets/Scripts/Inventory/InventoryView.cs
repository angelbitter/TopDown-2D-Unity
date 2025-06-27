using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private GameObject inventoryFrame;
    
    [SerializeField] private ItemSlot[] slots;
    [SerializeField] private ItemView itemViewPrefab;
    public static InventoryView Instance { get; private set; }

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryFrame.SetActive(!inventoryFrame.activeSelf);
            if (inventoryFrame.activeSelf)
            {
                UpdateInventory();
            }
        }
    }
    public void UpdateInventory()
    {
        List<ItemData> currentList = InventoryController.Instance.Items;
        if (currentList == null)
        {
            return;
        }
        for (int i = 0; i < currentList.Count; i++)
        {
            if (!slots[i].CurrentView)
            {
                ItemView itemViewCreated = Instantiate(itemViewPrefab, slots[i].transform);
                slots[i].CurrentView = itemViewCreated;
            }
            slots[i].CurrentView.SetItem(currentList[i]);
            slots[i].gameObject.SetActive(true);
        }
    }
}
