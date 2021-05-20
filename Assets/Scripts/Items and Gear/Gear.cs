using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equip", menuName = "Inventory/Gear")]
public class Gear : Item
{
    public gearTier tier;

    private int defaultArmour;
    private int defaultDamage;

    public int armour;
    public int damage;

    //these overrides are from a redudant system, might keep for future use
    #region
    public override void setArmour()
    {
        defaultArmour = armour;
        base.setArmour();
        armour = armour2;
    }

    public override void setDamage()
    {
        defaultDamage = damage;
        base.setDamage();
        damage = damage2;
    }

    public override void resetToDefaultMods()
    {
        base.resetToDefaultMods();
        damage = defaultDamage;
        armour = defaultArmour;
    }
    #endregion

    public int armour2;
    public int damage2;


}

public enum gearTier
{
    tier1, tier2, tier3, tier4, tier5
}

[System.Serializable]
public class ItemStack
{
    public gearTier tier;

    public Item baseItem;

    public bool defaultItem;

    public itemType overrideType;

    public Sprite GetSprite()
    {
        if (overrideType == itemType.Null)
        {
            return baseItem.icon;
        }
        else if (overrideType == baseItem.itemTypes[0])
        {
            return baseItem.transmute1;
        }
        else
        {
            return baseItem.transmute2;
        }
    }

    public ItemStack()
    {
        overrideType = itemType.Null;
        defaultItem = false;
    }

    public void UseItem()
    {
        Debug.Log($"Using item: {baseItem.name}");
        if (baseItem == null) return;

        if (baseItem.itemTypes.Count == 1 || overrideType != itemType.Null)
        {
            GearManager.Instance.Equip(this);
            InventoryRemove();
        }
        else
        {
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

    public float GetTierMultiplier()
    {
        return (1.0f + ((int)tier * 0.50f));
    }
}