using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Scriptable Objects/Item")]
public class ItemSO : ScriptableObject
{
    public int id;
    public float damage;
    public string itemName;
    public int levelNeeded;
    public Sprite icon;
    public string type;
}
