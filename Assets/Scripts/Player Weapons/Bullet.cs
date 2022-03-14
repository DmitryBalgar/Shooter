using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private int _damage;
    [SerializeField] private float _timeToDestroy;
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _particle;


    private Vector3 _shootDir;
    private Rigidbody2D _rb;

    public void Setup(Vector3 shootDir)
    {
        _shootDir = shootDir;
        transform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(shootDir));
        _rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, _timeToDestroy);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log(collision.transform.name + " collision");
        if (collision.gameObject.TryGetComponent<IDamageable>(out IDamageable damageable))
        {
            var contact = collision.contacts[0];
            
            damageable.TakeDamage(_damage, contact.point, _shootDir);
        }

        #region ParticleEffect
        GameObject hitEffect = Instantiate(_particle, transform.position, Quaternion.identity);
        Destroy(hitEffect, 1f);
        #endregion
        Destroy(gameObject);
    }


    private void FixedUpdate()
    {
        _rb.velocity = _shootDir * _speed;
    }
    private static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;

    }

}


