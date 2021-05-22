using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour
{
    private float attackCooldown = 0f;
    public float attackDelay = 0.6f;
    //delay for animations 

    public event System.Action OnAttack;
    //for anim

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
            StartCoroutine(damageDelay(targetStats, attackDelay));

            if (OnAttack != null)
            {
                OnAttack();
            }

            //rework attck speed & cooldown
            attackCooldown = 1f / myStats.attackSpeed.GetValue();
        }
    }

    IEnumerator damageDelay (CharacterStats stats, float delay)
    {
        yield return new WaitForSeconds(delay);

        stats.takeDmg(myStats.damage.GetValue());
    }

}
