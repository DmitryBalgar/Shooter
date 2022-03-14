using UnityEngine;

public class GunAmmo : MonoBehaviour
{
    [SerializeField] private int _ammoCount;
    [SerializeField] private Weapon.WeaponType _currentType;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerShoot>(out PlayerShoot playerShoot))
        {
            IncreaseAmmo(playerShoot, _currentType);
        }
    }
    private void IncreaseAmmo(PlayerShoot playerShoot, Weapon.WeaponType weaponType)
    {
        for (int i = 0; i < playerShoot.Weapons.Count; i++)
        {
            if (playerShoot.Weapons[i].CurrentWeapontype == weaponType)
            {
                if (playerShoot.Weapons[i].CurrentAmmo < playerShoot.Weapons[i].MaxAmmo)
                {
                    playerShoot.Weapons[i].IncreaseAmmo(_ammoCount);
                    Destroy(gameObject);
                    return;
                }
            }
        }
    }
}
