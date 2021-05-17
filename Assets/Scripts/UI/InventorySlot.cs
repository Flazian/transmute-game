using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    ItemStack item;
    
    public void AddItem(ItemStack newItem)
    {
        if (newItem.baseItem == null) return;
        item = newItem;
        icon.sprite = item.baseItem.icon;
        icon.enabled = true;
        removeButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void RemoveButton()
    {
        Inventory.instance.Remove(item);
    }

    public void ItemUse()
    {
        if (item != null)
        {
            item.UseItem();
        }
    }
}
