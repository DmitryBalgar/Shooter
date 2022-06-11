using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class EnemyDieState : State
{
    [SerializeField] private Animator _animator;

    private void OnEnable()
    {
        _animator.SetTrigger("isDead");
    }
}
