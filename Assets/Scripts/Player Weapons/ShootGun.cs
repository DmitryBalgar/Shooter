using UnityEngine;
using UnityEngine.Events;

public class ShootGun : Weapon
{
    public override event UnityAction<int> CurrentAmmoUpdate;
    private void Awake()
    {
        _currentAmmo = _maxAmmo;
        CurrentAmmoUpdate?.Invoke(_currentAmmo);
    }
    public override void Shoot(Transform shootPoint, Vector3 shootDir)
    {
        if (_currentAmmo <= 0) return;
        Bullet bullet1 = Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        bullet1.Setup(new Vector3(shootDir.x - 0.1f, shootDir.y));
        Bullet bullet2 = Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        bullet2.Setup(shootDir);
        Bullet bullet3 = Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        bullet3.Setup(new Vector3(shootDir.x, shootDir.y + 0.1f));

        MuzzleEffect(shootPoint);
        _currentAmmo--;
        CurrentAmmoUpdate?.Invoke(_currentAmmo);
    }
    public override void MuzzleEffect(Transform shootPoint)
    {
        GameObject clone = Instantiate(MuzzleeEfct, shootPoint.position, shootPoint.rotation);
        clone.transform.parent = shootPoint;
        Destroy(clone, 0.1f);
    }
    public override void ShowInfo()
    {
        CurrentAmmoUpdate?.Invoke(_currentAmmo);
    }


}