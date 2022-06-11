using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class RangeShootState : State
{
    [SerializeField] private float _attackDelay;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _bulletPrefab;

    public Pool BulletPool;

    private Animator _animator;
    private float _lastAttackTime = 0;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.Play("Shoot");
    }
    private void Update()
    {
        if (_lastAttackTime <= 0)
        {
            {
                Attack(Target);
                _lastAttackTime = _attackDelay;
            }
        }
        _lastAttackTime -= Time.deltaTime;
        RotateTowardsTarget();
    }


    private void Attack(PlayerHealth target)
    {
        _animator.Play("Shoot");
        Vector2 shootdir = target.transform.position - transform.position;
        Bullet clone = BulletPool.GetFreeElement(_shootPoint.position).GetComponent<Bullet>();
        clone.BulletInit(shootdir.normalized, 0);
    }
    private void RotateTowardsTarget()
    {
        Vector2 direction = Target.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(Vector3.forward * (angle));
    }
}
