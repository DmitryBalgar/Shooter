using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private GameObject _bloodParticle;


    private int _currentHealth;
    private Animator _anim;
    private CapsuleCollider2D _colider;

    private void Start()
    {
        _currentHealth = _maxHealth;
        _colider = GetComponent<CapsuleCollider2D>();
        _anim = GetComponent<Animator>();
    }
    public void TakeDamage(int damageValue, Vector2 contactPoint, Vector2 shootingDirection)
    {
        _currentHealth -= damageValue;
        ShowBlood(contactPoint, shootingDirection);
        if (_currentHealth <= 0)
        {
            _colider.enabled = false;
            _anim.SetTrigger("isDead");
            Destroy(gameObject, 3);
        }
    }

    private void ShowBlood(Vector2 contactPoint, Vector2 dir)
    {
        GameObject blood = Instantiate(_bloodParticle, contactPoint, Quaternion.LookRotation(dir));
        Destroy(blood, 2f);
    }
}
