using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private List<Weapon> _weapons;
    private Weapon _currentWeapon;
    private int _ind = 0;
    private int _currentAmmo;
    private bool _canShoot = true;
    public Weapon CurrentWeapon => _currentWeapon;
    public List<Weapon> Weapons => _weapons;

    public event UnityAction<Sprite> WeaponChanged;
    public event UnityAction<int, int> CurrentAmmoUpdateUI;

    private void Awake()
    {
        _currentWeapon = _weapons[_ind];
    }

    private void OnEnable()
    {
        _playerInput.onShoot += Shooting;
        _currentWeapon.CurrentAmmoUpdate += AmmoCountChange;
    }
    private void OnDisable()
    {
        _playerInput.onShoot -= Shooting;
        _currentWeapon.CurrentAmmoUpdate -= AmmoCountChange;
    }
    private void Start()
    {
        WeaponChanged?.Invoke(_currentWeapon.Icon);
        _currentWeapon.ShowInfo();
        CurrentAmmoUpdateUI?.Invoke(_currentAmmo, _currentWeapon.MaxAmmo);
    }

    private void Shooting(Vector2 dir)
    {
        if (_canShoot)
        {
            _currentWeapon.Shoot(_shootPoint, dir);
            _canShoot = false;
            StartCoroutine(ShootDelay());
        }
    }
    private void AmmoCountChange(int curentAmmo)
    {
        _currentAmmo = curentAmmo;
        CurrentAmmoUpdateUI?.Invoke(_currentAmmo, _currentWeapon.MaxAmmo);
    }

    private IEnumerator ShootDelay()
    {
        yield return new WaitForSeconds(_currentWeapon.CurrentDelay);
        _canShoot = true;
    }
    public void WeaponSwapRight()
    {
        _ind++;
        if (_ind > _weapons.Count - 1)
            _ind = 0;
        _currentWeapon.CurrentAmmoUpdate -= AmmoCountChange;
        _currentWeapon = _weapons[_ind];
        _currentWeapon.CurrentAmmoUpdate += AmmoCountChange;
        _currentWeapon.ShowInfo();
        WeaponChanged?.Invoke(_currentWeapon.Icon);
        CurrentAmmoUpdateUI?.Invoke(_currentAmmo, _currentWeapon.MaxAmmo);

    }
    public void WeaponSwapLeft()
    {
        _ind--;
        if (_ind < 0)
            _ind = _weapons.Count - 1;
        _currentWeapon.CurrentAmmoUpdate -= AmmoCountChange;
        _currentWeapon = _weapons[_ind];
        _currentWeapon.CurrentAmmoUpdate += AmmoCountChange;
        _currentWeapon.ShowInfo();
        WeaponChanged?.Invoke(_currentWeapon.Icon);
        CurrentAmmoUpdateUI?.Invoke(_currentAmmo, _currentWeapon.MaxAmmo);
    }
}
