using UnityEngine;
public class GunAmmo : Ammo
{
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        _spriteRenderer.sprite = CurrentAmmo.Sprite;
    }

}
