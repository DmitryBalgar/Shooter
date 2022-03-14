using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    public enum WeaponType { Pistol, MachinGun, Uzi, ShootGun }
    [SerializeField] private WeaponType _weaponType;
    //[SerializeField] private int _price;
    //[SerializeField] private bool _isBuyed = false;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _currentDelay;

    [SerializeField] protected int _maxAmmo;
    [SerializeField] protected Bullet Bullet;
    [SerializeField] protected GameObject MuzzleeEfct;

    protected int _currentAmmo;

    public abstract event UnityAction<int> CurrentAmmoUpdate;

    public int MaxAmmo => _maxAmmo;
    public int CurrentAmmo => _currentAmmo;
    public Sprite Icon => _icon;
    public float CurrentDelay => _currentDelay;
    public WeaponType CurrentWeapontype => _weaponType;

    public abstract void Shoot(Transform shootPoint, Vector3 shootDir);

    public abstract void MuzzleEffect(Transform shootPoint);

    public abstract void ShowInfo();
    public void IncreaseAmmo(int count)
    {
        _currentAmmo += count;
        if (_currentAmmo > _maxAmmo)
            _currentAmmo = _maxAmmo;
        ShowInfo();
    }
}
