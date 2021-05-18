using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GearManager : MonoBehaviour
{
    //singleton
    public static GearManager Instance;

    public int numGearSlots = 8;

    public Transmutation transmute;

    private InputAction unequipAllButton = new InputAction(binding: "<Keyboard>/u");
    

    [SerializeField] public ItemStack[] currentGear;

    public delegate void OnGearChanged(ItemStack newGear, ItemStack oldGear);
    public OnGearChanged onGearChanged;

    Inventory inventory;

    public Sprite helm;
    public Sprite chest;
    public Sprite gloves;
    public Sprite legs;
    public Sprite boots;
    public Sprite ring;
    public Sprite mainHand;
    public Sprite offHand;



    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        inventory = Inventory.instance;
        currentGear = new ItemStack[numGearSlots];
        InitializeGear();
        unequipAllButton.Enable();
    }

    private void InitializeGear()
    {
        for (int i = 0; i < currentGear.Length; i++)
        {
            currentGear[i] = new ItemStack();
        }
    }

    public void Equip(ItemStack newGear)
    {
        int slotIndex = 0;
        ItemStack oldGear = null;
        
        slotIndex = (int)newGear.GetItemType();

        #region
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
        #endregion

        //change this to chosen slot
        // this breask everything!
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

    //this might need to be chosenslot but idk
    public void Unequip(int slotIndex)
    {
        if (currentGear[slotIndex].baseItem != null)
        {
            ItemStack oldGear = currentGear[slotIndex];
            inventory.Add(oldGear);

            currentGear[slotIndex] = new ItemStack();

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
