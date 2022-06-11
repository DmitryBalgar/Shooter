using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootGun : Weapon
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
        Bullet clone1 = BulletsPool.GetFreeElement(shootPoint.position, Quaternion.identity).GetComponent<Bullet>();
        clone1.BulletInit(new Vector3(shootDir.x - 0.05f, shootDir.y - 0.05f) , _decreaseLifetimeBullet);
        Bullet clone2 = BulletsPool.GetFreeElement(shootPoint.position, Quaternion.identity).GetComponent<Bullet>();
        clone2.BulletInit(shootDir, _decreaseLifetimeBullet);
        Bullet clone3 = BulletsPool.GetFreeElement(shootPoint.position, Quaternion.identity).GetComponent<Bullet>();
        clone3.BulletInit(new Vector3(shootDir.x + 0.05f, shootDir.y + 0.05f), _decreaseLifetimeBullet);
        Bullet clone4 = BulletsPool.GetFreeElement(shootPoint.position, Quaternion.identity).GetComponent<Bullet>();
        clone4.BulletInit(new Vector3(shootDir.x, shootDir.y - 0.05f), _decreaseLifetimeBullet);
        Bullet clone5 = BulletsPool.GetFreeElement(shootPoint.position, Quaternion.identity).GetComponent<Bullet>();
        clone5.BulletInit(new Vector3(shootDir.x, shootDir.y + 0.05f), _decreaseLifetimeBullet);
        Bullet clone6 = BulletsPool.GetFreeElement(shootPoint.position, Quaternion.identity).GetComponent<Bullet>();
        clone6.BulletInit(new Vector3(shootDir.x - 0.05f, shootDir.y), _decreaseLifetimeBullet);
        Bullet clone7 = BulletsPool.GetFreeElement(shootPoint.position, Quaternion.identity).GetComponent<Bullet>();
        clone7.BulletInit(new Vector3(shootDir.x + 0.05f, shootDir.y), _decreaseLifetimeBullet);
        current.Add(clone1);
        current.Add(clone2);
        current.Add(clone3);
        current.Add(clone4);
        current.Add(clone5);
        current.Add(clone6);
        current.Add(clone7);

        BulletShellInstantiate(shootDir);


        BulletShoot?.Invoke(current);
        MuzzleEffect(shootPoint);
        CurrentAmmo--;
        CurrentAmmoUpdate?.Invoke(CurrentAmmo);
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