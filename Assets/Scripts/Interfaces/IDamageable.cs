using UnityEngine;

  interface IDamageable
{
    public void TakeDamage(int damageValue, Vector2 damagePoint, Vector2 shotingDirection);

}