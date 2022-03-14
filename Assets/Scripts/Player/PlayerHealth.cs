using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;
    
    
    private int _currentHealth;


    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void TakeDamage(int damageValue, Vector2 damagePoint, Vector2 shootingDir)
    {
        //UI event

        _currentHealth -= damageValue;
    }
}
