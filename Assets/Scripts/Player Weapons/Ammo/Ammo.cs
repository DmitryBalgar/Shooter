using UnityEngine;

public abstract class Ammo : MonoBehaviour
{
    [SerializeField] protected AmmoScriptableObject CurrentAmmo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerShoot>(out PlayerShoot playerShoot))
        {
            IncreaseAmmo(playerShoot, CurrentAmmo._currentType);
        }
    }
    private void IncreaseAmmo(PlayerShoot playerShoot, Weapon.WeaponType weaponType)
    {
        for (int i = 0; i < playerShoot.Weapons.Count; i++)
        {
            if (playerShoot.Weapons[i].CurrentWeapontype == weaponType)
            {
                if (playerShoot.Weapons[i].CurrentAmmunition < playerShoot.Weapons[i].MaxAmmunition)
                {
                    playerShoot.Weapons[i].IncreaseAmmo(CurrentAmmo._ammoCount);
                    Destroy(gameObject);
                    return;
                }
            }
        }
    }
}
