using UnityEngine;

[CreateAssetMenu(fileName = "Ammo", menuName = "Weapons/Ammo")]
public class AmmoScriptableObject : ScriptableObject
{
    public Weapon.WeaponType CurrentType;
    public Sprite Sprite;
    public int AmmoCount;
}
