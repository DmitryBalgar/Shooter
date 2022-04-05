using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : PoolObject
{
    [SerializeField] private int _damage;
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private float _speed;

    public event UnityAction<Vector3, Bullet> BulletHit;

    private Vector3 _shootDir;
    private Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void BulletInit(Vector3 shootDir)
    {
        _shootDir = shootDir;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shootDir));
        _rb.velocity = shootDir * _speed;
        ReturnToPool(_timeToDestroy);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            var contact = collision.contacts[0];
            damageable.TakeDamage(_damage, contact.point, _shootDir);
        }
        #region ParticleEffect
        BulletHit?.Invoke(transform.position, this);
        #endregion
        ReturnToPool();
    }

    private static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;

    }

}


