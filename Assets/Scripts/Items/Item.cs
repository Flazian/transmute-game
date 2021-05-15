using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    new public string name = "item";
    public Sprite icon = null;
    public bool defaultItem = false;

    public List<itemId> itemIds = new List<itemId>();

    public bool hasType(itemId _id)
    {
        for (int i = 0; i < itemIds.Count; i++)
        {
            if (_id == itemIds[i]) return true;
        }

        return false;
    }

    public virtual void UseItem()
    {
        Debug.Log("Using " + name);
    }

}



public enum itemId
{
    sword,
    helmet,
    mainhand
}