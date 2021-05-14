using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using UnityEngine;


public class ItemPickup : Interact
{
    public Item item;

    public override void use()
    {
        base.use();

        PickUp();
    }

    void PickUp()
    {
        Debug.Log("Picking up " + item.name);
        bool pickedUp = Inventory.instance.Add(item);
        if (pickedUp)
        {
            Destroy(gameObject);
        }
    }
}
