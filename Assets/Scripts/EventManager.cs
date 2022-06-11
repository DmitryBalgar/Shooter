using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventManager : MonoBehaviour
{
    public static EventManager Instance;
    [SerializeField] private List<GunAmmo> _ammoPrefab;
    [SerializeField] private PlayerHealth _playerHealth;

    public event UnityAction<IScore.ScoreTypes> ScoreIncrease;
    public PlayerHealth PlayerHealth => _playerHealth;
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance == this) Destroy(gameObject);
    }

    private void OnEnable()
    {

    }
    public void AddEmenyEvents(EnemyHealth enemy)
    {
        enemy.EnemyDeath += EnemyDeathEvents;
    }


    private void EnemyDeathEvents(Vector3 position, IScore.ScoreTypes scoreType, EnemyHealth enemy)
    {
        float dropChanse = 0.25f; // %
        float chanse = Random.Range(0f, 1f);
        if (chanse <= dropChanse)
        {
            DropAmmo(position);
        }
        IncreaseScore(scoreType);
        enemy.EnemyDeath -= EnemyDeathEvents;
    }
    private void DropAmmo(Vector3 position)
    {
        int index = Random.Range(0, _ammoPrefab.Count);
        Instantiate(_ammoPrefab[index], position, Quaternion.identity, this.transform);
    }
    private void IncreaseScore(IScore.ScoreTypes scoreType)
    {
        ScoreIncrease.Invoke(scoreType);
    }

}
