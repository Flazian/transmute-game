using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterCombat : MonoBehaviour
{
    private CharacterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    public void Attack (CharacterStats targetStats)
    {
        targetStats.takeDmg(20);
    }

}
