using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equip", menuName = "Inventory/Gear")]
public class Gear : Item
{
    public int armor;
    public int dmg;
}

[System.Serializable]
public class ItemStack
{
    public Item baseItem;

    public bool defaultItem;

    public itemType overrideType;

    public ItemStack()
    {
        overrideType = itemType.Null;
        defaultItem = false;
    }

    public void UseItem()
    {
        Debug.Log($"Using item: {baseItem.name}");

        if (baseItem.itemTypes.Count == 1 || overrideType != itemType.Null)
        {
            GearManager.instance.Equip(this);
            InventoryRemove();
        }
        else
        {
            //Debug.Log(Transmutation.instance);
            Transmutation.instance.transmute((int)baseItem.itemTypes[0], (int)baseItem.itemTypes[1], this);
        }

        //InventoryRemove();
    }

    public void InventoryRemove()
    {
        Inventory.instance.Remove(this);
    }

    public bool hasType(itemType _id)
    {
        for (int i = 0; i < baseItem.itemTypes.Count; i++)
        {
            if (_id == baseItem.itemTypes[i]) return true;
        }

        return false;
    }

    public List<itemType> GetItemTypes()
    {
        return baseItem.itemTypes;
    }

    public itemType GetItemType()
    {
        if (overrideType != itemType.Null)
        {
            return overrideType;
        }

        return baseItem.itemTypes[0];
    }
}