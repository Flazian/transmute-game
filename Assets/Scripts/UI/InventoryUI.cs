using UnityEngine;
using UnityEngine.InputSystem;

public class InventoryUI : MonoBehaviour
{
    public Transform itemParent;
    public GameObject inventoryUI;
    private InputAction invPress = new InputAction(binding: "<Keyboard>/i");

    Inventory inventory;

    InventorySlot[] slots;


    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.whenItemChangedCallback += UpdateUI;
        slots = itemParent.GetComponentsInChildren<InventorySlot>();
        invPress.AddBinding("<Keyboard>/b");
        invPress.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (invPress.triggered)
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI ()
    {
        Debug.Log("Updating ui YEEEEEEEEEEEEES");
        for(int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].AddItem(inventory.items[i]);
            }
            else
            {
                slots[i].ClearSlot();
            }
        }
    }
}
