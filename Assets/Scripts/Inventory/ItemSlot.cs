using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    [SerializeField] public ItemSO item;
    [SerializeField] public Image background;
    private Button button;
    public bool isSelected = false;
    private PlayerItemHandler player;

    
}
