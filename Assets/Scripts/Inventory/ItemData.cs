using System;
using UnityEngine;

[Serializable]
public class ItemData
{
    public int id;
    public string itemName;
    public Sprite itemSprite;
    public int amount = 1;
    public ItemData(ItemSO initData)
    {
        itemName = initData.itemName;
        itemSprite = initData.icon;
        id = initData.id;
    }
}
