using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterStats : MonoBehaviour
{
    private InputAction testDmg = new InputAction(binding: "<Keyboard>/t");

    public Stat maxHealth;

    public int currentHealth
    {
        get; private set;
    }

    public Stat damage;
    public Stat armour; // diminishing returns implement later 

    private void Awake()
    {
        maxHealth.setBaseValue(100);
        currentHealth = maxHealth.GetValue();
        testDmg.Enable();
    }

    private void Update()
    {
        if (testDmg.triggered)
        {
            takeDmg(120);
        }
    }

    public void takeDmg(int damage)
    {

        //grim dawn style 30% of dmg always gets through if over armour value, 70% is reduced by armour
        //if dmg lower than armour reduce all of it by 70%
        //this is nice because it sort-of makes armour more effective earlier, 
        //and reduces its effectiveness when stacking LOTS of armour points
        int totalDamage = 0;

        Debug.Log("damage: " + damage);


        if (damage > armour.GetValue())
        {
            int leftover = Mathf.Abs(damage - armour.GetValue());
            totalDamage += leftover;

            float reduced = damage + armour.GetValue();
            reduced -= damage;
            reduced = reduced * 0.30f;
            int newReduced;
            newReduced = (int)reduced;

            totalDamage += newReduced;

        } 
        else if (damage <= armour.GetValue())
        {
            // reduce all damage by 70%

            float allReduce = damage * 0.30f;

            totalDamage = (int)allReduce;
        }

        //damage -= armour.GetValue();
        //damage = Mathf.Clamp(damage, 0, int.MaxValue);

        currentHealth -= totalDamage;
        Debug.Log(transform.name + " takes " + totalDamage + " damage.");

        if (currentHealth <= 0)
        {
            death();
        }
    }

    public virtual void death()
    {
        //kill player or character
        //overwrite
        Debug.Log(transform.name + " died.");
    }
}
