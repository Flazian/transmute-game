using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "item";
    public Sprite icon = null;
    public bool defaultItem = false;

    public List<itemType> itemTypes = new List<itemType>();
}



public enum itemType
{
    Helm, Chest, Gloves, Legs, Boots, Ring, MainHand, OffHand, TwoHand, Potion, Null
}