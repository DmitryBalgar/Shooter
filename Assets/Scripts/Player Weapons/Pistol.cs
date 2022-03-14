using UnityEngine;
using UnityEngine.Events;

public class Pistol : Weapon
{
    public override event UnityAction<int> CurrentAmmoUpdate;
    private void Awake()
    {
        _currentAmmo = _maxAmmo;
        CurrentAmmoUpdate?.Invoke(_currentAmmo);
    }
    public override void MuzzleEffect(Transform shootPoint)
    {
        GameObject clone = Instantiate(MuzzleeEfct, shootPoint.position, shootPoint.rotation);
        clone.transform.parent = shootPoint;
        Destroy(clone, 0.1f);
    }

    public override void Shoot(Transform shootPoint, Vector3 shootDir)
    {
        Bullet bullet = Instantiate(Bullet, shootPoint.position, Quaternion.identity);
        bullet.Setup(shootDir);
        MuzzleEffect(shootPoint);
        CurrentAmmoUpdate?.Invoke(_currentAmmo);

    }
    public override void ShowInfo()
    {
        CurrentAmmoUpdate?.Invoke(_currentAmmo);
    }
}
