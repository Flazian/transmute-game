using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{

    new public string name = "item";
    public Sprite icon = null;
    public bool defaultItem = false;
    public virtual void setArmour()
    {
        Debug.Log("set armour");
    }

    //redundant for now, keeping for later use maybe
    #region
    public virtual void setDamage()
    {
        Debug.Log("set damage");
    }

    public virtual void resetToDefaultMods()
    {
        Debug.Log("reset damage + armour to 1st item type");
    }
    #endregion

    public List<itemType> itemTypes = new List<itemType>();
}



public enum itemType
{
    Helm, Chest, Gloves, Legs, Boots, Ring, MainHand, OffHand, TwoHand, Potion, Null
}