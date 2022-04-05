using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class Weapon : MonoBehaviour
{
    public enum WeaponType { Pistol, MachinGun, ShootGun }
    [SerializeField] private WeaponType _weaponType;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _currentDelay;

    [SerializeField] protected int MaxAmmo;
    [SerializeField] protected Pool BulletsPool;
    [SerializeField] protected Pool MuzzleEffectsPool;
    [SerializeField] protected Rigidbody2D ShellPrefab;
    [SerializeField] private Transform _shellPositionSpawm;

    protected int CurrentAmmo;
    public abstract event UnityAction<int> CurrentAmmoUpdate;
    public abstract event UnityAction<List<Bullet>> BulletShoot;

    private static List<Rigidbody2D> _shellList = new List<Rigidbody2D>();
    private static int _shellIndex = 0;

    public int MaxAmmunition => this.MaxAmmo;
    public int CurrentAmmunition => CurrentAmmo;
    public Sprite Icon => _icon;
    public float CurrentDelay => _currentDelay;
    public WeaponType CurrentWeapontype => _weaponType;

    public abstract void Shoot(Transform shootPoint, Vector3 shootDir);
    public abstract void MuzzleEffect(Transform shootPoint);
    public abstract void AmmoUIUpdate();
    public void IncreaseAmmo(int count)
    {
        CurrentAmmo += count;
        if (CurrentAmmo > MaxAmmo)
            CurrentAmmo = MaxAmmo;
        AmmoUIUpdate();
    }
    public void BulletShellInstantiate(Vector3 spawnDir)
    {
        float startSpeed = Random.Range(2f, 4.5f);
        Vector3 _currentSpawnPoint = _shellPositionSpawm.position;

        Rigidbody2D shellRb = Instantiate(ShellPrefab, _currentSpawnPoint , Quaternion.identity, _shellPositionSpawm);

        var dir = new Vector2(spawnDir.normalized.x * startSpeed, spawnDir.normalized.y * startSpeed);
        shellRb.velocity = Quaternion.Euler(0, 0, -90f) * dir;
        shellRb.rotation = Random.Range(0, 360f);

        _shellList.Add(shellRb);
        _shellIndex++;
        if (_shellIndex > 200)
        {
            Destroy(_shellList[0].gameObject);
            _shellList.Remove(_shellList[0]);
            _shellIndex--;
        }
    }

}
