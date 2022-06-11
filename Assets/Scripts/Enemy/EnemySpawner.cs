using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyPrefabs;
    [SerializeField] private Pool _enemyBulletsPool;
    [SerializeField] private LevelData _levelData;
    [SerializeField] private List<EnemyFactory> _enemyFactorys;

    private Camera _mainCamera;

    private void Awake()
    {
        _mainCamera = Camera.main;
    }
    private void Start()
    {
        for (int i = 0; i < 30; i++)
        {
            GetEnemy();
        }
    }
    private void GetEnemy()
    {
        #region SpawnPoint
        float height = _mainCamera.orthographicSize + 1;
        float width = _mainCamera.orthographicSize * _mainCamera.aspect + 1;

        int point = Random.Range(0, 4);
        Vector3 spawnPoint = Vector3.zero;
        switch (point)
        {
            case 0:
                //top
                 spawnPoint = new Vector3(_mainCamera.transform.position.x + Random.Range(-width, width),
                                    _mainCamera.transform.position.y + height + Random.Range(10, 30),
                                    0);
                break;
            case 1:
                //down
                 spawnPoint = new Vector3(_mainCamera.transform.position.x + Random.Range(-width, width),
                                     _mainCamera.transform.position.y - height - Random.Range(10, 30),
                                     0);
                break;
            case 2:
                //left
                 spawnPoint = new Vector3(_mainCamera.transform.position.x + Random.Range(-width * 2, -width),
                                     _mainCamera.transform.position.y + Random.Range(-height, height),
                                     0);
                break;
            case 3:
                //right
                 spawnPoint = new Vector3(_mainCamera.transform.position.x + Random.Range(width, width * 2),
                                      _mainCamera.transform.position.y + Random.Range(-height, height),
                                      0);
                break;
        }
        #endregion
        int index = Random.Range(0, _enemyFactorys.Count);
        GameObject clone = _enemyFactorys[index].CreateEnemy(spawnPoint);



        //GameObject clone = Instantiate(_enemyPrefabs[index], spawnPoint, Quaternion.identity);
        EventManager.Instance.AddEmenyEvents(clone.GetComponentInChildren<EnemyHealth>());
        if (clone.TryGetComponent(out RangeShootState rangeShootState) == true)
            rangeShootState.BulletPool = _enemyBulletsPool;

    }
}
