using System.Collections;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private WeaponController _weaponController;
    [SerializeField] private Transform _shootPoint;
    private bool _canShoot = true;


    private void OnEnable()
    {
        _playerInput.onShoot += Shooting;
    }
    private void OnDisable()
    {
        _playerInput.onShoot -= Shooting;
    }
    private void Shooting(Vector2 dir)
    {
        if (_canShoot)
        {
            _weaponController.CurrentWeapon.Shoot(_shootPoint, dir);
            _canShoot = false;
            StartCoroutine(ShootDelay(_weaponController.CurrentWeapon));
        }
    }
    private IEnumerator ShootDelay(Weapon currentWeapon)
    {
        yield return new WaitForSeconds(currentWeapon.CurrentDelay);
        _canShoot = true;
    }

}
