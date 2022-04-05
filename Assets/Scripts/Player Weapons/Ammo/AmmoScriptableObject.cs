using UnityEngine;

[CreateAssetMenu(fileName = "Ammo", menuName = "Weapons/Ammo")]
public class AmmoScriptableObject : ScriptableObject
{
    public Weapon.WeaponType _currentType;
    public Sprite _sprite;
    public int _ammoCount;
}
