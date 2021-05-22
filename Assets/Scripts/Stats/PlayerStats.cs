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
                    armour.addValue(Mathf.RoundToInt(((float)g.armour) * newGear.GetTierMultiplier()));
                    damage.addValue(Mathf.RoundToInt(((float)g.damage) * newGear.GetTierMultiplier()));
                }
                else if (newGear.overrideType == itemType.Null)
                {
                    armour.addValue(Mathf.RoundToInt(((float)g.armour) * newGear.GetTierMultiplier()));
                    damage.addValue(Mathf.RoundToInt(((float)g.damage) * newGear.GetTierMultiplier()));
                }
                else
                {
                    armour.addValue(Mathf.RoundToInt(((float)g.armour2) * newGear.GetTierMultiplier()));
                    damage.addValue(Mathf.RoundToInt(((float)g.damage2) * newGear.GetTierMultiplier()));
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
                    armour.removeValue(Mathf.RoundToInt(((float)gg.armour) * oldGear.GetTierMultiplier()));
                    damage.removeValue(Mathf.RoundToInt(((float)gg.damage) * oldGear.GetTierMultiplier()));
                }
                else if (oldGear.overrideType == itemType.Null)
                {
                    armour.removeValue(Mathf.RoundToInt(((float)gg.armour) * oldGear.GetTierMultiplier()));
                    damage.removeValue(Mathf.RoundToInt(((float)gg.damage) * oldGear.GetTierMultiplier()));
                }
                else
                {
                    armour.removeValue(Mathf.RoundToInt(((float)gg.armour2) * oldGear.GetTierMultiplier()));
                    damage.removeValue(Mathf.RoundToInt(((float)gg.damage2) * oldGear.GetTierMultiplier()));
                }
            }
        }
    }

    public override void death()
    {
        base.death();
        PlayerManager.instance.playerDeath();
        //Application.Quit();
    }

}
