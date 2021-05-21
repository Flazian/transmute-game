using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    private float attackCooldown = 0f;

    private CharacterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void Attack (CharacterStats targetStats)
    {
        if (attackCooldown <= 0f)
        {
            targetStats.takeDmg(myStats.damage.GetValue());

            //rework attck speed & cooldown
            attackCooldown = 1f / myStats.attackSpeed.GetValue();
        }
    }

}
