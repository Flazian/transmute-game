using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
    // Start is called before the first frame update
    void Start()
    {
        GearManager.Instance.onGearChanged += OnGearChanged;
    }

    void OnGearChanged (ItemStack newGear, ItemStack oldGear)
    {
        Debug.Log($"oldGear {oldGear}");
        if (newGear.baseItem != null)
        {
            if (newGear.baseItem is Gear)
            {
                Gear g = newGear.baseItem as Gear;
                if (newGear.overrideType == newGear.GetItemTypes()[0])
                {
                    armour.addValue(g.armour);
                    damage.addValue(g.damage);
                }
                else if (newGear.overrideType == itemType.Null)
                {
                    armour.addValue(g.armour);
                    damage.addValue(g.damage);
                }
                else
                {
                    armour.addValue(g.armour2);
                    damage.addValue(g.damage2);
                }
            }
        }

        if (oldGear.baseItem != null)
        {
            if (oldGear.baseItem is Gear)
            {
                Gear gg = oldGear.baseItem as Gear;
                if (oldGear.overrideType == oldGear.GetItemTypes()[0])
                {
                    armour.removeValue(gg.armour);
                    damage.removeValue(gg.damage);
                }
                else if (oldGear.overrideType == itemType.Null)
                {
                    armour.removeValue(gg.armour);
                    damage.removeValue(gg.damage);
                }
                else
                {
                    armour.removeValue(gg.armour2);
                    damage.removeValue(gg.damage2);
                }
            }
        }
    }

}
