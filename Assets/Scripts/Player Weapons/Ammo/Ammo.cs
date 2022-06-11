using UnityEngine;

public abstract class Ammo : MonoBehaviour
{
    [SerializeField] protected AmmoScriptableObject CurrentAmmo;
    [SerializeField] private GameObject _playerAmmoPopUpPrefab;
    
    private int _currentIncrease;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<WeaponController>(out WeaponController weaponChanger))
        {
            IncreaseAmmo(weaponChanger, CurrentAmmo.CurrentType);
        }
    }
    private void IncreaseAmmo(WeaponController weaponChanger, Weapon.WeaponType ammoType)
    {
        for (int i = 0; i < weaponChanger.Weapons.Count; i++)
        {
            if (weaponChanger.Weapons[i].CurrentWeapontype == ammoType)
            {
                if (weaponChanger.Weapons[i].CurrentAmmunition < weaponChanger.Weapons[i].MaxAmmunition)
                {
                    if (weaponChanger.Weapons[i].CurrentAmmunition + CurrentAmmo.AmmoCount > weaponChanger.Weapons[i].MaxAmmunition)
                        _currentIncrease = weaponChanger.Weapons[i].MaxAmmunition - weaponChanger.Weapons[i].CurrentAmmunition;
                    else _currentIncrease = CurrentAmmo.AmmoCount;

                    weaponChanger.Weapons[i].IncreaseAmmo(_currentIncrease);
                    Instantiate(_playerAmmoPopUpPrefab, transform.localPosition + Vector3.up/2, Quaternion.identity, null).GetComponent<PlayerAmmoPopUp>().ShowIncome(_currentIncrease, weaponChanger.Weapons[i]);
                    Destroy(gameObject);
                    return;
                }
            }
        }
    }
}
