using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MachinGun : Weapon
{
    public override event UnityAction<int> CurrentAmmoUpdate;
    public override event UnityAction<List<Bullet>> BulletShoot;

    private void Awake()
    {
        CurrentAmmo = MaxAmmo;
        CurrentAmmoUpdate?.Invoke(CurrentAmmo);
    }
    public override void Shoot(Transform shootPoint, Vector3 shootDir)
    {
        if (CurrentAmmo <= 0) return;
        List<Bullet> current = new List<Bullet>();

        for (int i = 0; i < 5; i++)
        {
            Bullet clone = BulletsPool.GetFreeElement(new Vector3(shootPoint.position.x + Random.Range(-0.2f, 0.2f),
                                                            shootPoint.position.y + Random.Range(-0.2f, 0.2f),
                                                            shootPoint.position.z),
                                                            Quaternion.identity).GetComponent<Bullet>();
            clone.BulletInit(shootDir);
            CurrentAmmo--;
            CurrentAmmoUpdate?.Invoke(CurrentAmmo);

            current.Add(clone);

        }
        BulletShellInstantiate(shootDir);
        BulletShoot?.Invoke(current);
        MuzzleEffect(shootPoint);
    }

    public override void MuzzleEffect(Transform shootPoint)
    {
        MuzzleEffectsPool.GetFreeElement(shootPoint.position, shootPoint.rotation);
    }

    public override void AmmoUIUpdate()
    {
        CurrentAmmoUpdate?.Invoke(CurrentAmmo);
    }

}
