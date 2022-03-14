using UnityEngine;

interface IDamageable
{
     void TakeDamage(int damageValue, Vector2 damagePoint, Vector2 shotingDirection);
}