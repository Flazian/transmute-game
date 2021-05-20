using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
    public override void death()
    {
        base.death();
        // die and ragdoll

        Destroy(gameObject);
    }
}
