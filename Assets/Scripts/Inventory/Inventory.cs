using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //singleton
    public static Inventory instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one inventory");
            return;
        }
        instance = this;
    }

    //delegate
    public delegate void WhenItemChanged();
    public WhenItemChanged whenItemChangedCallback;

    public int invSpace = 15;

    public List<Item> items = new List<Item>();

    public bool Add (Item item)
    {
        if (!item.defaultItem)
        {
            if (items.Count >= invSpace)
            {
                Debug.Log("No inventory room");
                return false;
            }
            items.Add(item);

            if (whenItemChangedCallback != null)
            {
                whenItemChangedCallback.Invoke();
            }
        }

        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (whenItemChangedCallback != null)
        {
            whenItemChangedCallback.Invoke();
        }
    }

}
