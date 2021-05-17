using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GearManager : MonoBehaviour
{
    //singleton
    public static GearManager instance;

    public int numGearSlots = 8;

    public Transmutation transmute;

    private InputAction unequipAllButton = new InputAction(binding: "<Keyboard>/u");


    [SerializeField] ItemStack[] currentGear;

    public delegate void OnGearChanged(ItemStack newGear, ItemStack oldGear);
    public OnGearChanged onGearChanged;

    Inventory inventory;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        inventory = Inventory.instance;
        currentGear = new ItemStack[numGearSlots];
        unequipAllButton.Enable();
    }

    public void Equip(ItemStack newGear)
    {
        int slotIndex = 0;
        ItemStack oldGear = null;

        slotIndex = (int)newGear.GetItemType();
            
        /*else if (newGear.itemTypes.Count == 2)
        {
            slotIndex = (int)newGear.itemTypes[0];
            slotIndex2 = (int)newGear.itemTypes[1];
            transmute.transmute(slotIndex, slotIndex2);
            
            if (transmute.choice == 1)
            {
                
                chosenSlot = slotIndex;
            }
            else if (transmute.choice == 2)
            {
                
                chosenSlot = slotIndex2;
            }
        } */



        
        //change this to chosen slot
         if (currentGear[slotIndex].baseItem != null)
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

    IEnumerator waitToChangeGear()
    {
        yield return new WaitUntil(() => transmute.choiceMade == true);
    }


    //this might need to be chosenslot but idk
    public void Unequip(int slotIndex)
    {
        if (currentGear[slotIndex].baseItem != null)
        {
            ItemStack oldGear = currentGear[slotIndex];
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
