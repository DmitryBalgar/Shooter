using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    public GameObject CreateEnemy(Vector3 pos)
    {
        return Instantiate(_enemyPrefab, pos, Quaternion.identity);
    }
}
