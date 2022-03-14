using UnityEngine;
using UnityEngine.Events;

public class MachinGun : Weapon
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
        for (int i = 0; i < 5; i++)
        {
            Bullet bullet = Instantiate(Bullet, new Vector3(shootPoint.position.x + Random.Range(-0.2f, 0.2f),
                                                            shootPoint.position.y + Random.Range(-0.2f, 0.2f),
                                                            shootPoint.position.z),
                                                            Quaternion.identity);
            bullet.Setup(shootDir);
            _currentAmmo--;
            CurrentAmmoUpdate?.Invoke(_currentAmmo);
        }
        MuzzleEffect(shootPoint);

    }
    public override void MuzzleEffect(Transform shootPoint)
    {
        GameObject clone = Instantiate(MuzzleeEfct, shootPoint.position, shootPoint.rotation);
        clone.transform.parent = shootPoint;
        Destroy(clone, 0.05f);
    }
    public override void ShowInfo()
    {
        CurrentAmmoUpdate?.Invoke(_currentAmmo);
    }
}
