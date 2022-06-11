using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDieTransition : Transition
{
    [SerializeField] private EnemyHealth _enemyHealth;

    private void Update()
    {
        if(_enemyHealth.IsAlive == false)
        {
            NeedTransit = true;
        }
    }
}
