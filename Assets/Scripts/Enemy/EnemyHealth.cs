using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour, IDamageable, IScore
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private GameObject _bloodParticle;
    [SerializeField] private IScore.ScoreTypes _scoreType;

    public event UnityAction<Vector3, IScore.ScoreTypes,  EnemyHealth> EnemyDeath;

    private int _currentHealth;
    private Animator _anim;
    private CapsuleCollider2D _colider;
    private bool _isAlive = true;
    public bool IsAlive => _isAlive;

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
        if (_currentHealth <= 0 && _isAlive)
        {
            _isAlive = false;
            _colider.enabled = false;

            EnemyDeath.Invoke(transform.position, _scoreType, this);
            Destroy(gameObject, 3);
        }
    }

    private void ShowBlood(Vector2 contactPoint, Vector2 dir)
    {
        GameObject blood = Instantiate(_bloodParticle, contactPoint, Quaternion.LookRotation(dir));
        Destroy(blood, 1f);
    }
}
