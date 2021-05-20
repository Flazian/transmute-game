using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stat 
{
    [SerializeField] private int baseValue;

    [SerializeField] private List<int> modifiers = new List<int>();

    public int GetValue()
    {
        int finalValue = baseValue;
        modifiers.ForEach(x => finalValue += x);
        return finalValue;
    }

    public void setBaseValue(int value)
    {
        baseValue = value;
    }

    public void addValue (int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Add(modifier);
        }
    }

    public void removeValue (int modifier)
    {
        if (modifier != 0)
        {
            modifiers.Remove(modifier);
        }
    }
}
