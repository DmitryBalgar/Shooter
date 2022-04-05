using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Pistol : Weapon
{
    public override event UnityAction<int> CurrentAmmoUpdate;
    public override event UnityAction<List<Bullet>> BulletShoot;

    private void Awake()
    {
        CurrentAmmo = MaxAmmo;
        AmmoUIUpdate();
    }

    public override void Shoot(Transform shootPoint, Vector3 shootDir)
    {
        List<Bullet> shootedBullets = new List<Bullet>();

        Bullet clone = BulletsPool.GetFreeElement(shootPoint.position).GetComponent<Bullet>();
        clone.BulletInit(shootDir);
        shootedBullets.Add(clone);
        
        MuzzleEffect(shootPoint);

        BulletShellInstantiate(shootDir);

        CurrentAmmoUpdate?.Invoke(CurrentAmmo);
        BulletShoot?.Invoke(shootedBullets);
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
