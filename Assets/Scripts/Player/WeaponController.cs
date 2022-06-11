using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WeaponController: MonoBehaviour
{
    private int _ind = 0;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private List<Weapon> _weapons;
    private Weapon _currentWeapon;
    private int _currentAmmo;
    public Weapon CurrentWeapon => _currentWeapon;
    public List<Weapon> Weapons => _weapons;

    public event UnityAction<Sprite> WeaponChanged;
    public event UnityAction<int, int> CurrentAmmoUpdateUI;

    private void Awake()
    {
        _currentWeapon = _weapons[0];
    }
    private void OnEnable()
    {
        _currentWeapon.CurrentAmmoUpdate += AmmoCountChange;
    }
    private void OnDisable()
    {
        _currentWeapon.CurrentAmmoUpdate -= AmmoCountChange;
    }
    private void Start()
    {
        WeaponChanged?.Invoke(_currentWeapon.Icon);
        _currentWeapon.AmmoUIUpdate();
        CurrentAmmoUpdateUI?.Invoke(_currentAmmo, _currentWeapon.MaxAmmunition);
    }
    public void WeaponSwapRight()
    {
        _ind++;
        if (_ind > _weapons.Count - 1)
            _ind = 0;
        _currentWeapon.CurrentAmmoUpdate -= AmmoCountChange;
        _currentWeapon = _weapons[_ind];
        _currentWeapon.CurrentAmmoUpdate += AmmoCountChange;
        _currentWeapon.AmmoUIUpdate();
        WeaponChanged?.Invoke(_currentWeapon.Icon);
        CurrentAmmoUpdateUI?.Invoke(_currentAmmo, _currentWeapon.MaxAmmunition);

    }
    public void WeaponSwapLeft()
    {
        _ind--;
        if (_ind < 0)
            _ind = _weapons.Count - 1;
        _currentWeapon.CurrentAmmoUpdate -= AmmoCountChange;
        _currentWeapon = _weapons[_ind];
        _currentWeapon.CurrentAmmoUpdate += AmmoCountChange;
        _currentWeapon.AmmoUIUpdate();
        WeaponChanged?.Invoke(_currentWeapon.Icon);
        CurrentAmmoUpdateUI?.Invoke(_currentAmmo, _currentWeapon.MaxAmmunition);
    }
    private void AmmoCountChange(int curentAmmo)
    {
        _currentAmmo = curentAmmo;
        CurrentAmmoUpdateUI?.Invoke(_currentAmmo, _currentWeapon.MaxAmmunition);
    }
}
