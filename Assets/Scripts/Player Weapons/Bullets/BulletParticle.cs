using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletParticle : MonoBehaviour
{
    [SerializeField] private Pool _particlePool;
    [SerializeField] private List<Weapon> _currentWeapon;
    [SerializeField] private float _reternToPoolTime;
    private List<Bullet> _bullets;

    private void OnEnable()
    {
        for (int i = 0; i < _currentWeapon.Count; i++)
        {
            _currentWeapon[i].BulletShoot += SetUpBullet;
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < _currentWeapon.Count; i++)
        {
            _currentWeapon[i].BulletShoot -= SetUpBullet;
        }
    }

    private void SetUpBullet(List<Bullet> current)
    {
        _bullets = current;
        for (int i = 0; i < _bullets.Count; i++)
        {
            _bullets[i].BulletHit += StartParticle;
        }
        StartCoroutine(UnSubscribe(_reternToPoolTime));
    }

    private void StartParticle(Vector3 pos, Bullet currentBullet)
    {
        var obj = _particlePool.GetFreeElement(pos);
        obj.ReturnToPool(_reternToPoolTime);
        currentBullet.BulletHit -= StartParticle;

    }
    IEnumerator UnSubscribe(float time)
    {
        yield return new WaitForSeconds(time);
        for (int i = 0; i < _bullets.Count; i++)
        {
            _bullets[i].BulletHit -= StartParticle;
        }
    }

}
