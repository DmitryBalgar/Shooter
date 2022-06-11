using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveToTargetState : State
{
    [SerializeField] private float _speed;
    [SerializeField] private Animator _animator;
    private void OnEnable()
    {
        _animator.Play("Walk");
    }
    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, _speed * Time.deltaTime);
        RotateTowardsTarget();
    }
    private void RotateTowardsTarget()
    {
        Vector2 direction = Target.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle));
    }
}
