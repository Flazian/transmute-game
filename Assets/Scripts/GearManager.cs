using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearManager : MonoBehaviour
{
    //singleton
    public static GearManager instance;

    public int numGearSlots = 8;

    public GameObject canvas;

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] Gear[] currentGear;

    private void Start()
    {
        currentGear = new Gear[numGearSlots];
    }

    public void Equip(Gear newGear)
    {
        int slotIndex = 0;
        int slotIndex2 = 0;
        int chosenSlot = 0;

        if( newGear.itemTypes.Count == 1)
        {
            slotIndex = (int)newGear.itemTypes[0];
        }
        else if (newGear.itemTypes.Count >= 2)
        {
            slotIndex = (int)newGear.itemTypes[0];
            slotIndex2 = (int)newGear.itemTypes[1];
        }

        currentGear[slotIndex] = newGear;
    }
}
