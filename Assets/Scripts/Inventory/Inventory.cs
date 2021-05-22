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

    public List<ItemStack> items = new List<ItemStack>();

    public bool Add(ItemStack item)
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

    public void Remove(ItemStack item)
    {
        items.Remove(item);
        if (whenItemChangedCallback != null)
        {
            whenItemChangedCallback.Invoke();
        }
    }

}
