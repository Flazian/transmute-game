using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GearManager : MonoBehaviour
{
    //singleton
    public static GearManager instance;

    public int numGearSlots = 8;

    public GameObject canvas;

    private InputAction unequipAllButton = new InputAction(binding: "<Keyboard>/u");

    private void Awake()
    {
        instance = this;
    }

    [SerializeField] Gear[] currentGear;

    public delegate void OnGearChanged(Gear newGear, Gear oldGear);
    public OnGearChanged onGearChanged;

    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.instance;
        currentGear = new Gear[numGearSlots];
        unequipAllButton.Enable();
    }

    public void Equip(Gear newGear)
    {
        int slotIndex = 0;
        int slotIndex2 = 0;
        int chosenSlot = 0;
        Gear oldGear = null;

        if ( newGear.itemTypes.Count == 1)
        {
            slotIndex = (int)newGear.itemTypes[0];
        }
        else if (newGear.itemTypes.Count >= 2)
        {
            slotIndex = (int)newGear.itemTypes[0];
            slotIndex2 = (int)newGear.itemTypes[1];
        }

        //change this to chosen slot
        if (currentGear[slotIndex] != null)
        {
            oldGear = currentGear[slotIndex];
            inventory.Add(oldGear);
        }

        if (onGearChanged != null)
        {
            onGearChanged.Invoke(newGear, oldGear);
        }

        //change this to chosen slot
        currentGear[slotIndex] = newGear;
    }


    //this might need to be chosenslot but idk
    public void Unequip(int slotIndex)
    {
        if (currentGear[slotIndex] != null)
        {
            Gear oldGear = currentGear[slotIndex];
            inventory.Add(oldGear);

            currentGear[slotIndex] = null;

            if (onGearChanged != null)
            {
                onGearChanged.Invoke(null, oldGear);
            }

        }
    }

    public void UnequipAll()
    {
        for (int i = 0; i < currentGear.Length; i++)
        {
            Unequip(i);
        }
    }

    void Update()
    {
        if(unequipAllButton.triggered)
        {
            UnequipAll();
        }
    }
}
