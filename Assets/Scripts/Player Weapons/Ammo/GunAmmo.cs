using UnityEngine;
public class GunAmmo : Ammo
{
    private SpriteRenderer _spriteRenderer;
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = CurrentAmmo._sprite;
    }

}
