using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "item";
    public Sprite icon = null;
    public bool defaultItem = false;

    public List<itemType> itemTypes = new List<itemType>();

    public bool hasType(itemType _id)
    {
        for (int i = 0; i < itemTypes.Count; i++)
        {
            if (_id == itemTypes[i]) return true;
        }

        return false;
    }

    public virtual void UseItem()
    {
        Debug.Log("Using " + name);
    }

    public void InventoryRemove()
    {
        Inventory.instance.Remove(this);
    }

}



public enum itemType
{
    Helm, Chest, Gloves, Legs, Boots, Ring, MainHand, OffHand, TwoHand, Potion
}