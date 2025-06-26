using UnityEngine;

public class InventoryView : MonoBehaviour
{
    [SerializeField] private GameObject inventoryFrame;
    
    [SerializeField] private ItemSlot[] slots;
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
        // for (int i = 0; i < slots.Length; i++)
        // {
        //     if (i < InventoryController.Instance.items.Count)
        //     {
        //         slots[i].gameObject.SetActive(true);
        //         slots[i].SetItem(InventoryController.Instance.GetItem(i));
        //     }
        //     else
        //     {
        //         slots[i].gameObject.SetActive(false);
        //     }
        // }
    }
}
