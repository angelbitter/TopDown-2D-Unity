using System;
using UnityEngine;
using UnityEngine.UI;
public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject inventoryFrame;
    
    [SerializeField] private ItemSlot[] slots;

    private int availableItems = 0;

    void Start()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            int buttonIndex = i;
            Debug.Log($"Button {i} initialized");
            // slots[i].onClick.AddListener(() => OnButtonClick(buttonIndex));
        }
    }

    private void OnButtonClick(int i)
    {
        
        // ItemButton itemButton = buttons[i].GetComponent<ItemButton>();
        // if (itemButton.isSelected)
        // {
        //     Deselect(itemButton);
        // }
        // else
        // {
        //     Select(itemButton);
        // }
    }

    // private void Select(ItemButton button)
    // {
    //     Debug.Log($"Selected item: {button.item.name}");
    //     button.isSelected = true;
    // }
    // private void Deselect(ItemButton button)
    // {
    //     Debug.Log($"Selected item: {button.item.name}");
    //     button.isSelected = false;
    //     // button.Sele.color = Color.white;
    //     // player.SetSelectedItem(null);
    // }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryFrame.SetActive(!inventoryFrame.activeSelf);
        }
    }

    public void AddItem(ItemSO item)
    {
        slots[availableItems].gameObject.SetActive(true);
        slots[availableItems].GetComponent<Image>().sprite = item.icon;
        // buttons[availableItems].GetComponent<ItemButton>().item = item;
        // slots[availableItems].onClick.AddListener(() => OnButtonClick(availableItems));
        availableItems++;
    }
}
