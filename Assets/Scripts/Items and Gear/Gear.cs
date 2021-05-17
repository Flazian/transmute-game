using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Equip", menuName = "Inventory/Gear")]
public class Gear : Item
{


    public int armor;
    public int dmg;

    public override void UseItem()
    {
        base.UseItem();
        GearManager.instance.Equip(this);

        InventoryRemove();
    }

}