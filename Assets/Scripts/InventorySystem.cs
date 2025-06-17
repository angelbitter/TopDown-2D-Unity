using System;
using UnityEngine;
using UnityEngine.UI;
public class InventorySystem : MonoBehaviour
{
    [SerializeField] private GameObject inventoryFrame;
    [SerializeField] private Button[] buttons;

    private int availableItems = 0;

    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            int buttonIndex = i;
            buttons[i].onClick.AddListener(() => OnButtonClick(buttonIndex));
        }
    }

    private void OnButtonClick(int i)
    {
        Debug.Log($"Button {i} clicked");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryFrame.SetActive(!inventoryFrame.activeSelf);
        }
    }

    public void AddItem(ItemSO item)
    {
        buttons[availableItems].gameObject.SetActive(true);
        buttons[availableItems].GetComponent<Image>().sprite = item.icon;
        availableItems++;
    }
}
